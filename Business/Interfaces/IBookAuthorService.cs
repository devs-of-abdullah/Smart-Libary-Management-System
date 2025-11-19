using Entity;


namespace Business.Interfaces
{
    public interface IBookAuthorService
    {
        Task AddAsync(BookAuthor bookAuthor);
        Task DeleteAsync(int bookId, int authorId);
    }

}
