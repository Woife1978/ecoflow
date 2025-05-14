import React, { useEffect, useState } from 'react';
import { Line } from 'react-chartjs-2';
import {
  Chart as ChartJS,
  LineElement,
  CategoryScale,
  LinearScale,
  PointElement,
  Tooltip,
  Legend,
} from 'chart.js';

ChartJS.register(LineElement, CategoryScale, LinearScale, PointElement, Tooltip, Legend);

const EcoFlowDashboard = () => {
  const themes = ['light', 'dark', 'nixie'];
  const [theme, setTheme] = useState(() => localStorage.getItem('theme') || 'light');
  const [timeRange, setTimeRange] = useState(60);
  const [solarData, setSolarData] = useState([]);
  const [summary, setSummary] = useState({
    batterySoc: '--%',
    gridStatus: '--',
    solarNow: '--',
    loadNow: '-- W',
    invol: '--',
    inamp: '--',
    invoutamp: '--',
  });
  const [flow, setFlow] = useState({
    gridToHome: '--',
    solarToBattery: '--',
    batteryToHome: '--',
  });

  useEffect(() => {
    document.documentElement.setAttribute('data-theme', theme);
    localStorage.setItem('theme', theme);
  }, [theme]);

  const toggleTheme = () => {
    const currentIndex = themes.indexOf(theme);
    const nextIndex = (currentIndex + 1) % themes.length;
    setTheme(themes[nextIndex]);
  };

  const fetchBatteryData = async (seconds) => {
    try {
      const res = await fetch(`/api/BatteryData/last?seconds=${seconds}`);
      const json = await res.json();

      if (json.length > 0) {
        const latest = json[json.length - 1];
        setSummary((prev) => ({
          ...prev,
          batterySoc: `${latest.soc}%`,
          extrabattery1soc: latest.extrabattery1soc > 0 ? `${latest.extrabattery1soc}%` : '--%',
          extrabattery2soc: latest.extrabattery2soc > 0 ? `${latest.extrabattery2soc}%` : '--%',
          loadNow: latest.outwatts > 0 ? `${latest.outwatts} W` : '-- W',
        }));
      }
    } catch (error) {
      console.error('Failed to fetch battery data', error);
    }
  };

  const fetchSolarData = async (seconds) => {
    try {
      const res = await fetch(`/api/SolarData/last?seconds=${seconds}`);
      const json = await res.json();
      setSolarData(json);

      if (json.length > 0) {
        const latest = json[json.length - 1];
        setSummary((prev) => ({ 
          ...prev, 
          solarNow: `${latest.input}`,
          invol: latest.invol/10 || '--', // Ensure invol is updated here
          inamp: latest.inamp/100 || '--', // Ensure inamp is updated here
          invoutamp: latest.invoutamp/100 || '--', // Ensure invoutamp is updated here 
        }));
      }
    } catch (error) {
      console.error('Failed to fetch solar data', error);
    }
  };

  useEffect(() => {
    fetchBatteryData(timeRange);
    fetchSolarData(timeRange);
    const interval = setInterval(() => {
      fetchBatteryData(timeRange);
      fetchSolarData(timeRange);
    }, 1000);
    return () => clearInterval(interval);
  }, [timeRange]);

  const solarChartData = {
    labels: solarData.map(d => new Date(d.datetime).toLocaleTimeString()),
    datasets: [{
      label: 'Solar Input (Watts)',
      data: solarData.map(d => d.input),
      borderColor: 'rgba(75, 192, 192, 1)',
      backgroundColor: 'rgba(75, 192, 192, 0.2)',
      borderWidth: 2,
      pointRadius: 0,
    }]
  };

  const chartOptions = {
    responsive: true,
    scales: {
      y: {
        beginAtZero: true,
        max: 1600,
      }
    },
    plugins: {
      legend: {
        labels: {
          color: theme === 'dark' ? '#eee' : theme === 'nixie' ? '#ff4500' : '#333'
        }
      }
    }
  };

  const renderNixieNumber = (value) => {
      console.log('Rendering Nixie number:', value);

      // Ensure the value is defined and is a string
      if (!value || typeof value !== 'string') {
        console.error('Invalid value passed to renderNixieNumber:', value);
        return (
          <div className="nixie-container">
            <div className="nixie-digit" data-digit="-"></div>
          </div>
        );
      }

      // Remove all spaces from the value
      const cleanedValue = value.replace(/\s+/g, '');

      // Ensure the cleaned value contains numeric characters
      if (!/\d/.test(cleanedValue)) {
        console.error('Invalid numeric value:', cleanedValue);
        return (
          <div className="nixie-container">
            <div className="nixie-digit" data-digit="-"></div>
          </div>
        );
      }

      // Extract digits before the decimal point (e.g., "99.99%" -> "99", "999 W" -> "999")
      const numericPart = cleanedValue.split('.')[0].replace(/[^0-9]/g, '');
      const numericValue = parseInt(numericPart, 10);

      // Handle cases where numericValue is NaN
      if (isNaN(numericValue)) {
        console.error('Invalid numeric value after parsing:', cleanedValue);
        return (
          <div className="nixie-container">
            <div className="nixie-digit" data-digit="-"></div>
          </div>
        );
      }

      // Split the numeric value into individual digits
      const digits = numericValue.toString().split('');
      return (
        <div className="nixie-container">
          {digits.map((digit, index) => (
            <div key={index} className="nixie-digit" data-digit={digit}></div>
          ))}
        </div>
      );
  };

  const renderNumber = (value) => {
  if (theme === 'nixie') {
    // Render nixie-style numbers
    return renderNixieNumber(value);
  } else {
    // Render plain text numbers
    return <span>{value}</span>;
  }
};

  return (
    <div className="dashboard">
      <header style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
        <h1>EcoFlow Dashboard</h1>
        <button onClick={toggleTheme} style={toggleButtonStyle}>
          {theme === 'light' ? '🌙 Dark Mode' : theme === 'dark' ? '🕹 Nixie Mode' : '☀ Light Mode'}
        </button>
      </header>

      <div style={{
        display: 'grid',
        gridTemplateColumns: '1fr',
        gap: 20,
        maxWidth: 1000,
        margin: '0 auto'
      }}>
        /* System Summary Panel */
          <div className="panel">
            <h2>System Summary</h2>
            <table className="data-table">
              <thead>
                <tr>
            <th>Battery SOC</th>
            <th>Extra Battery 1 SOC</th>
            <th>Extra Battery 2 SOC</th>
            <th>Grid Status</th>
            <th>Solar Input</th>
            <th>Home Load</th>
                </tr>
              </thead>
              <tbody>
            <tr>
              <td>{renderNumber(summary.batterySoc)}</td>
              <td>{renderNumber(summary.extrabattery1soc)}</td>
              <td>{renderNumber(summary.extrabattery2soc)}</td>
              <td>{summary.gridStatus}</td>
              <td>{renderNumber(summary.solarNow)}</td>
              <td>{renderNumber(summary.loadNow)}</td>
            </tr>
              </tbody>
            </table>
          </div>

          {/* New Table for Inverter Data */}
          <div className="panel">
            <h2>Inverter Data</h2>
            <table className="data-table">
              <thead>
                <tr>
            <th>Inverter Voltage (V)</th>
            <th>Input Current (A)</th>
            <th>Output Current (A)</th>
                </tr>
              </thead>
              <tbody>
                <tr>
            <td>{renderNumber(summary.invol || '--')}</td>
            <td>{renderNumber(summary.inamp || '--')}</td>
            <td>{renderNumber(summary.invoutamp || '--')}</td>
                </tr>
              </tbody>
            </table>
          </div>

          {/* Solar Chart Panel */}
        <div className="panel">
          <h2>Solar Input Over Time</h2>
          <label htmlFor="timeRange">Select Time Range: </label>
          <select
            id="timeRange"
            value={timeRange}
            onChange={(e) => setTimeRange(e.target.value)}
            style={{ margin: '10px 0', padding: 5 }}
          >
            <option value={60}>Last 60 seconds</option>
            <option value={300}>Last 5 minutes</option>
            <option value={3600}>Last hour</option>
            <option value={86400}>Last day</option>
            <option value={604800}>Last week</option>
          </select>
          <Line data={solarChartData} options={chartOptions} />
        </div>

        {/* Power Flow Panel */}
        <div className="panel">
          <h2>Power Flow</h2>
          <table className="data-table">
            <thead>
              <tr>
                <th>Source</th>
                <th>Direction</th>
                <th>Destination</th>
                <th>Power (W)</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Grid</td>
                <td>→</td>
                <td>Home</td>
                <td>{flow.gridToHome}</td>
              </tr>
              <tr>
                <td>Solar</td>
                <td>→</td>
                <td>Battery</td>
                <td>{flow.solarToBattery}</td>
              </tr>
              <tr>
                <td>Battery</td>
                <td>→</td>
                <td>Home</td>
                <td>{flow.batteryToHome}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <style>{`
          :root {
            --bg-color: #f9f9f9;
            --text-color: #111;
            --panel-bg: #fff;
            --border-color: #ddd;
            --nixie-color: #ff4500;
            --nixie-glow: rgba(255, 69, 0, 0.5);
          }
          [data-theme="dark"] {
            --bg-color: #121212;
            --text-color: #eee;
            --panel-bg: #1f1f1f;
            --border-color: #444;
          }
          [data-theme="nixie"] {
            --bg-color: #000;
            --text-color: #ff4500;
            --panel-bg: #111;
            --border-color: #ff4500;
            --nixie-color: #ff4500;
            --nixie-glow: rgba(255, 69, 0, 0.8);
          }
          body, .dashboard {
            background-color: var(--bg-color);
            color: var(--text-color);
            font-family: Arial, sans-serif;
            padding: 20px;
          }
          .panel {
            background: var(--panel-bg);
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
          }
          .data-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
          }
          .data-table th, .data-table td {
            border: 1px solid var(--border-color);
            padding: 8px;
            text-align: center;
          }
          .data-table th {
            background-color: rgba(255, 255, 255, 0.1);
          }

          .nixie-container {
            display: flex; /* Use flexbox to align items horizontally */
            justify-content: center; /* Center the digits horizontally */
            align-items: center; /* Align digits vertically in the middle */
            /* gap: 5px; Add spacing between digits */
          }

          .nixie-digit {
              width: 90px; /* Adjusted for 1080px width divided by 12 digits (90px per digit) */
              height: 75px; /* Adjusted for the reference height */
              background: url('/nixie.png') no-repeat;
              background-size: 1080px 150px; /* Match the sprite sheet dimensions */
              /*margin: 0 2px;*/
            }
            .nixie-digit[data-digit="0"] { background-position: 0 0; }
            .nixie-digit[data-digit="1"] { background-position: -90px 0; }
            .nixie-digit[data-digit="2"] { background-position: -180px 0; }
            .nixie-digit[data-digit="3"] { background-position: -270px 0; }
            .nixie-digit[data-digit="4"] { background-position: -360px 0; }
            .nixie-digit[data-digit="5"] { background-position: -450px 0; }
            .nixie-digit[data-digit="6"] { background-position: -540px 0; }
            .nixie-digit[data-digit="7"] { background-position: -630px 0; }
            .nixie-digit[data-digit="8"] { background-position: -720px 0; }
            .nixie-digit[data-digit="9"] { background-position: -810px 0; }
            .nixie-digit[data-digit="-"] { background-position: -900px 0; } /* Optional for '-' */
          `}</style>
    </div>
  );
};

const toggleButtonStyle = {
  padding: '8px 12px',
  fontSize: '14px',
  borderRadius: '6px',
  cursor: 'pointer',
  border: '1px solid #ccc',
  backgroundColor: '#eee',
};

export default EcoFlowDashboard;