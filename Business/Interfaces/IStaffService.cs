namespace Business.Interfaces
{
    public interface IStaffService
    {
        Task<string?> LoginAsync(string username, string password);
        Task<bool> RegisterStaffAsync(string? FirstName, string? LastName, string Username, string Password, string? Role);
    }

}
