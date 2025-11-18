using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{

    public class Fine
    {
        public int Id { get; set; }

        public int LoanId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public DateTime DateIssued { get; set; } = DateTime.UtcNow;

        public DateTime? DatePaid { get; set; } 

        public bool IsPaid { get; set; } = false; 

        public Loan? Loan { get; set; }

        public bool IsOutstanding => !IsPaid && DateTime.UtcNow > DateIssued;
    }
}
