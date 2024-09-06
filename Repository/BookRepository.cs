using BookStoreAPI.Data;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace BookStoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _dbContext;
        public BookRepository( BookDbContext context) 
        { 
            _dbContext = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();
            
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
                return null;
            return book;

        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateBookAsync(int id, Book Updatedbook)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
                return null;

            book.Title = Updatedbook.Title;
            book.Author = Updatedbook.Author;
            book.Description = Updatedbook.Description;

            await _dbContext.SaveChangesAsync();
            return book;

        }
        public async Task<Book> DeleteBookAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
                return null;

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return book;

        }

        

      
    }
}
