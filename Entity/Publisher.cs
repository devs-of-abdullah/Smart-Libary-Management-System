
namespace Entity{
    public class Publisher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
