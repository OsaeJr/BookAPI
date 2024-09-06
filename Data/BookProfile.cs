using AutoMapper;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
namespace BookStoreAPI.Data

{
    public class BookProfile : Profile
    {

        public BookProfile() 
        {
            CreateMap<Book, BookDto>();
        }
        
    }
}
