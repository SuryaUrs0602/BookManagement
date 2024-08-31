using BookManagement.Models;
using BookManagement.Repositories.Contracts;
using BookManagement.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using BookManagement.Exceptions;
using System.Data.Entity.Infrastructure;
using DbUpdateConcurrencyException = Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException;
using DbUpdateException = Microsoft.EntityFrameworkCore.DbUpdateException;

namespace BookManagement.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task Add(Book obj)
        {
            try
            {
                _logger.LogDebug($"Adding a new book {obj}");
                await _bookRepository.Add(obj);
            }

            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "An Error occured while processing the request");
                throw new DomainInternalServerError("Some error occurred while processing");
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "An Error occured while processing the request");
                throw new DomainInternalServerError("Some Error Occurred while processing");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "An Error occured while processing the request");
                throw new DomainInternalServerError("Some Error occurred  while processing");
            }
        }

        public async Task Delete(object id)
        {
            try
            {
                _logger.LogDebug($"Deleting the book with {id}");
                await _bookRepository.Delete(id);
            }

            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "An Error occured while processing the request");
                throw new DomainInternalServerError("Some error occured while Processing");
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "An Error occured while processing the request");
                throw new DomainInternalServerError("Some error occured while processing");
            }
        }

        public async Task Edit(object id, BookDTO obj)
        {
            try
            {
                _logger.LogDebug($"Editing the book with {id}");
                await _bookRepository.Edit(id, obj);
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "An Error occured while processing the request");
                throw new DomainInternalServerError("Some error occured while processing");
            }

            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "An Error occured while processing the request");
                throw new DomainInternalServerError("Some error occured while processing");
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "An Error occured while processing the request");
                throw new DomainInternalServerError("Some error occured while processing");
            }
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all the books data");
                return await _bookRepository.GetAll();
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "An Error occured while processing the request");
                throw new DomainInternalServerError("Some error occured while processing");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "An Error occured while processing the request");
                throw new DomainInternalServerError("Some error occured while processing");
            }
        }

        public async Task<Book> GetById(object id)
        {
            try
            {
                _logger.LogDebug($"Getting the book {id}");
                return await _bookRepository.GetById(id);
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "An Error occured while processing the request");
                throw new DomainInternalServerError("Some error occurred while processing");
            }
        }
    }
}
