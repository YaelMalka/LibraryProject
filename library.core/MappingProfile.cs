using AutoMapper;
using Libary;
using Library.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Borrow, BorrowDTO>()
             .ForMember(dest => dest.BookIds,
                        opt => opt.MapFrom(src => src.BorrowBooks.Select(bb => bb.BookId)))
             .ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();

          
            CreateMap<Book, BookDTO>().ReverseMap();
        }
        
    }
}
