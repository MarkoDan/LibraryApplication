namespace LibraryApplication.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }


    }
}
