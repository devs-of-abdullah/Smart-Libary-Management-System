using Entity;

namespace API.DTOs
{
    
    public class BookDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }
      
        public string? ISBN { get; set; }
        public int PublicationYear { get; set; }
        public int CopiesTotal { get; set; }
        public int CopiesAvailable { get; set; }
         public int AuthorId {  get; set; }
        public Author? Author { get; set; }
        public int GenreId { get; set; }
        public GenreDto? Genre { get; set; }
        public int PublisherId { get; set; }
        public PublisherDto? Publisher { get; set; }

    }

    public class CreateBookDto
    {
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public int PublicationYear { get; set; }
        public int CopiesTotal { get; set; }

        public int GenreId { get; set; }
        public int PublisherId { get; set; }
        public  int AuthorId { get; set; }
    }
    public class UpdateBookDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? ISBN { get; set; }
        
        public int PublicationYear { get; set; }
        public int CopiesTotal { get; set; }
        public int CopiesAvailable { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }

    }
}
