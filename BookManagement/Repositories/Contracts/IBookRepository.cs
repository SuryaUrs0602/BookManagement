using BookManagement.Models;

namespace BookManagement.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task Add(Book obj);

        Task Delete(object id);

        Task Edit(object id, BookDTO obj);

        Task<Book> GetById(object id);

        Task<IEnumerable<Book>> GetAll();
    }
}
