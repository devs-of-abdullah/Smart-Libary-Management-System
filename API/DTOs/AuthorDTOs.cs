namespace API.DTOs
{
 
    public class AuthorDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int? BirthYear { get; set; }

    }
    public class UpdateAuthorDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? BirthYear { get; set; }
    }
    public class CreateAuthorDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? BirthYear { get; set; }
    }
}
