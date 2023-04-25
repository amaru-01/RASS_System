using System.ComponentModel.DataAnnotations;

namespace RASS_System.Models
{
    public class Police
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Rank { get; set; }

        public int BadgeNumber { get; set; }

        public int PhoneNo { get; set; }
    }
}
