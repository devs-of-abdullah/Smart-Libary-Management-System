using Entity;

namespace Business.Interfaces
{
    public interface IFineService
    {
        Task<IEnumerable<Fine>> GetAllFinesAsync();
        Task<Fine?> GetFineByIdAsync(int id);
        Task AddFineAsync(Fine fine);
        Task MarkFinePaidAsync(int id);
    }
}