namespace API.DTOs
{
    public class CreateLoanDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class LoanDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsOverdue { get; set; }
    }
}
