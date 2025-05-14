    public class BatterySocVoltageTracker
    {
        public int id { get; set; } // Primary key
        public string devicename { get; set; }
        public string serialnumber { get; set; }
        public DateTime datetime { get; set; }
        public decimal soc { get; set; }
        public decimal extrabattery1soc { get; set; }
        public decimal extrabattery2soc { get; set; }
        public int voltage { get; set; }
        public int outwatts { get; set; }
    }