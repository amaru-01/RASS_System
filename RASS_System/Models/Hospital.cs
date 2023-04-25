using System.ComponentModel.DataAnnotations;

namespace RASS_System.Models
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }  

        public string State { get; set; }

        public int ZipCode { get; set; }

        public int Contact { get; set; }

    }
}
