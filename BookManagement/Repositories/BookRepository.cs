using BookManagement.Exceptions;
using BookManagement.Models;
using BookManagement.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;
        private readonly DbSet<Book> _dbSet;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(BookDbContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _dbSet = _context.Set<Book>();
            _logger = logger;
        }

        public async Task Add(Book obj)
        {
            _logger.LogInformation("Trying to add new Book");
            _dbSet.Add(obj);    
            _logger.LogDebug($"book {obj}");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Successfully added the book");
        }

        public async Task Delete(object id)
        {
            _logger.LogInformation("Trying to delete the book");
            var book = await _dbSet.FindAsync(id);

            if (book != null)
            {
                _logger.LogDebug($"BookID {id} is found");
                _dbSet.Remove(book);
                _context.SaveChanges();
                _logger.LogInformation("Deleted the book succesfully");
            }

            //if (book == null)
            //{
            //    _logger.LogWarning($"bookID {id} not found");
            //    throw new DomainNotFound("Could not find the data that you want to delete");
            //}
        }

        public async Task Edit(object id, BookDTO obj)
        {
            _logger.LogInformation("Attempting to edit the book");

            var book = await _dbSet.FindAsync(id);

            if (book != null)
            {
                _logger.LogDebug($"BookID {id} is found");
                _dbSet.Entry(book).CurrentValues.SetValues(obj);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Edited the book with bookID {id} successfully");
            }

            //if (book == null)
            //{
            //    _logger.LogWarning($"bookID {id} not found");
            //    throw new DomainNotFound("Could not find the data to edit");
            //}
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            _logger.LogInformation("Attempting to fetch all the books");
            return await _dbSet.ToListAsync();
        }

        public async Task<Book> GetById(object id)
        {
            _logger.LogInformation("Attempting to fetch the book");
            return await _dbSet.FindAsync(id);
        }        
    }
}
