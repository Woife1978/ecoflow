public class SolarInputOutputTracker
{
    public int id { get; set; } // Primary key
    public string devicename { get; set; }
    public string serialnumber { get; set; }
    public DateTime datetime { get; set; }
    public int input { get; set; }
    public int output { get; set; }
    public int invol { get; set; }
    public int inamp { get; set; }
    public int invoutamp { get; set; }
}