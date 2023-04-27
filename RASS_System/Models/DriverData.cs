namespace RASS_System.Models
{
    public class DriverData
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public int Contact { get; set; }

        public int LicenseNumber { get; set; }

        public string MedicalInfo { get; set; }

        // FOREIGN KEY DEPLOYMENT
        public int AccidentID { get; set; }
        public accidentData? accidentData { get; set; }

        public int VehicleID { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
