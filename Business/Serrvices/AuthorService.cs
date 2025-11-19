using Business.Interfaces;
using Data.Interfaces;
using Entity;

namespace Business.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorService(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepo.GetAllAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await _authorRepo.GetByIdAsync(id);
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _authorRepo.AddAsync(author);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            await _authorRepo.UpdateAsync(author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _authorRepo.DeleteAsync(id);
        }
    }
}
