namespace API.DTOs
{
    public class CreateReservationDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
    }

    public class ReservationDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime? ReadyForPickupDate { get; set; }
        public string? Status { get; set; }
    }
}

