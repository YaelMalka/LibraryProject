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
        MappingProfile() { 
            CreateMap<Borrow,BorrowDTO>().ReverseMap();
        }
        
    }
}
