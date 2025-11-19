using Data.Interfaces;
using Data.Repositories;
using Entity;
using Business.Interfaces;
namespace Business.Services
{
  
    public class BookAuthorService : IBookAuthorService
    {
        private readonly IBookAuthorRepository _repo;
        public BookAuthorService(IBookAuthorRepository repo) => _repo = repo;

        public Task AddAsync(BookAuthor ba) => _repo.AddAsync(ba);
        public Task DeleteAsync(int bookId, int authorId) => _repo.RemoveAsync(bookId, authorId);
    }
}
