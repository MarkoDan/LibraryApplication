using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }

    }
}
