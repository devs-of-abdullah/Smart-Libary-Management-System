using Data.Interfaces;
using Entity;
using Business.Interfaces;
namespace Business.Services
{
   

    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _repo;
        public PublisherService(IPublisherRepository repo) => _repo = repo;

        public Task<IEnumerable<Publisher>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Publisher?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Publisher publisher) => _repo.AddAsync(publisher);
        public Task UpdateAsync(Publisher publisher) => _repo.UpdateAsync(publisher);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
