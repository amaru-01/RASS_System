namespace RASS_System.Models
{
    public class accidentData
    {
        public int ID { get; set; }

        public DateTime lastUpdated { get; set; }

        public string subBase { get; set; }

        public string county { get; set; }

        public string road { get; set; }

        public string place { get; set; }

        public string severity { get; set; }

        public string description { get; set; }

        public string weather { get; set; }

        public int hospitalID { get; set; }

        public int policeID { get; set; }

    }
}
