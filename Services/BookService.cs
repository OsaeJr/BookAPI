using BookStoreAPI.Interfaces;
using BookStoreAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using BookStoreAPI.DTOs;

namespace BookStoreAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _BookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository BookRepository,IMapper mapper) 
        {
            _BookRepository = BookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooks()
        {
            var books =  await _BookRepository.GetAllBooksAsync();

            var booksDTo = _mapper.Map<IEnumerable<BookDto>>(books);
            return booksDTo;
        }

        public async Task<BookDto> GetById(int id)
        {
            var book = await _BookRepository.GetBookByIdAsync(id);

            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
            
        }
        public async Task<BookDto> CreateBook(Book book)
        {
            var createBook = await _BookRepository.CreateBookAsync(book);
            
            var bookDto = _mapper.Map<BookDto>(createBook);

            return bookDto;
        }

        public async Task<BookDto> UpdateBook(int id, Book Updatedbook)
        {
            var book = await _BookRepository.UpdateBookAsync(id, Updatedbook);

            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }
        public async Task<BookDto> DeleteById(int id)
        {
            var book = await _BookRepository.DeleteBookAsync(id);

            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;

        }

        


    }
}
