    public class BatterySocVoltageTracker
    {
        public int id { get; set; } // Primary key
        public string devicename { get; set; }
        public string serialnumber { get; set; }
        public DateTime datetime { get; set; }
        public int soc { get; set; }
        public int extrabattery1soc { get; set; }
        public int extrabattery2soc { get; set; }
        public int voltage { get; set; }
    }