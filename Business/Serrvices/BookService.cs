using Data.Interfaces;
using Entity;
using Business.Interfaces;

namespace Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public Task<IEnumerable<Book>> GetAllBooksAsync() =>
            _bookRepo.GetAllAsync();

        public Task<Book?> GetBookByIdAsync(int id) =>
            _bookRepo.GetByIdAsync(id);

        public Task<Book?> AddBookAsync(Book book) =>
            _bookRepo.AddAsync(book);

        public Task<Book?> UpdateBookAsync(Book book) =>
            _bookRepo.UpdateAsync(book);

        public Task<bool> DeleteBookAsync(int id) =>
            _bookRepo.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id) =>
            _bookRepo.ExistsAsync(id);
    }
}

