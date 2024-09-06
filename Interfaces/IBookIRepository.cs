using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllBooksAsync();
        public Task<Book> GetBookByIdAsync(int id);
        public Task<Book> CreateBookAsync(Book book);
        public Task<Book> UpdateBookAsync(int id, Book book);
        public Task<Book> DeleteBookAsync(int id);

    }
}
