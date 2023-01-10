using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;

namespace BookStore.API.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<Books, BookModel>().ReverseMap();
        
        }
    }
}
