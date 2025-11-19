using Data.Interfaces;
using Entity;
using Business.Interfaces;
namespace Business.Services
{
    

    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repo;
        public GenreService(IGenreRepository repo) => _repo = repo;

        public Task<IEnumerable<Genre>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Genre?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Genre genre) => _repo.AddAsync(genre);
        public Task UpdateAsync(Genre genre) => _repo.UpdateAsync(genre);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
