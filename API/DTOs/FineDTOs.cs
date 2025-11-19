namespace API.DTOs
{
    public class CreateFineDto
    {
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
    }

    public class FineDto
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime? DatePaid { get; set; }
        public bool IsPaid { get; set; }
    }
}
