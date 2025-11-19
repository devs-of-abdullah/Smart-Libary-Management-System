

namespace Business.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public List<BookSimpleDto>? Books { get; set; }
    }

    public class BookSimpleDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
    }

}
