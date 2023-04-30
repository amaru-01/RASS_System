namespace RASS_System.Models
{
    public class Driver
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public int Conatct { get; set; }

        public int LicenceNo { get; set; }

        public string MedicalInfo { get; set; }

        public int AccidentID { get; set; }        

        public int VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
