using AutoMapper;
using Libary.Models;

namespace Libary
{
    public class MappingModels:Profile
    {
        public MappingModels()
        {
            CreateMap<CustomerPostModel, Customer>();
            CreateMap<BorrowPostModel, Borrow>();
            CreateMap<CustomerPutModel, Customer>();
        }
    }
}
