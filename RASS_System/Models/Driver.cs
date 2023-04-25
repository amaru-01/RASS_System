namespace RASS_System.Models
{
    public class Driver
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        // Property to get or set the date portion only
        public DateTime DateOfBirthDateOnly
        {
            get { return DateOfBirth.Date; }
            set { DateOfBirth = value.Date; }
        }

        public int Contact { get; set; }

        public string LicenseNumber { get; set; }

        public int MedicalInfo { get; set; }

        public int AccidentID { get; set; }

        public int VehicleID { get; set; }
    }
}
