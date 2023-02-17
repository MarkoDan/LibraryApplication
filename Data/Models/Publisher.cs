using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.Data.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
