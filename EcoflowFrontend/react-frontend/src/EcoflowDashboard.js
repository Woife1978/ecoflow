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
  const [timeRange, setTimeRange] = useState(60);
  const [solarData, setSolarData] = useState([]);
  const [darkMode, setDarkMode] = useState(
    () => localStorage.getItem('darkMode') === 'true'
  );
  const [summary, setSummary] = useState({
    batterySoc: '--%',
    gridStatus: '--',
    solarNow: '-- W',
    loadNow: '-- W',
  });
  const [flow, setFlow] = useState({
    gridToHome: '--',
    solarToBattery: '--',
    batteryToHome: '--',
  });

  useEffect(() => {
    document.documentElement.setAttribute(
      'data-theme',
      darkMode ? 'dark' : 'light'
    );
    localStorage.setItem('darkMode', darkMode);
  }, [darkMode]);

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
        setSummary((prev) => ({ ...prev, solarNow: `${latest.input} W` }));
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
          color: darkMode ? '#eee' : '#333'
        }
      }
    }
  };

  return (
    <div className="dashboard">
      <header style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
        <h1>EcoFlow Dashboard</h1>
        <button onClick={() => setDarkMode(!darkMode)} style={toggleButtonStyle}>
          {darkMode ? '☀ Light Mode' : '🌙 Dark Mode'}
        </button>
      </header>

      <div style={{
        display: 'grid',
        gridTemplateColumns: '1fr',
        gap: 20,
        maxWidth: 1000,
        margin: '0 auto'
      }}>
        
        {/* System Summary Panel */}
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
                <td>{summary.batterySoc}</td>
                <td>{summary.extrabattery1soc}</td>
                <td>{summary.extrabattery2soc}</td>
                <td>{summary.gridStatus}</td>
                <td>{summary.solarNow}</td>
                <td>{summary.loadNow}</td>
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
        }
        [data-theme="dark"] {
          --bg-color: #121212;
          --text-color: #eee;
          --panel-bg: #1f1f1f;
          --border-color: #444;
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
