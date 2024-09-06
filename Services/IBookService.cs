using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Services
{
    public interface IBookService
    {

        public Task<IEnumerable<BookDto>> GetAllBooks();
        public Task<BookDto> GetById(int id);
        public Task<BookDto> CreateBook(Book book);
        public Task<BookDto> UpdateBook(int id, Book Updatedbook);
        public Task<BookDto> DeleteById(int id);
    }
}
