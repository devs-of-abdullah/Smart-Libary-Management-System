namespace API.DTOs
{
    public class RegisterStaffDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Role { get; set; } = "admin"; //admin,manager
    }

    public class StaffDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class StaffLoginDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
