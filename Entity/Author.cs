
namespace Entity
{

    public class Author
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? BirthYear { get; set; } 

        public string FullName => $"{FirstName} {LastName}";

       
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
