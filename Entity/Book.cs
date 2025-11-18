
namespace Entity
{
    using System.Collections.Generic;

    public class Book
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? ISBN { get; set; } 
        public int PublicationYear { get; set; }
        public int CopiesTotal { get; set; }
        public int CopiesAvailable { get; set; } 

        public int GenreId { get; set; }
        public int PublisherId { get; set; }


        public Genre? Genre { get; set; }

        public Publisher? Publisher { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
