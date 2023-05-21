using AutoMapper;
using Bussines.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap(); 
            CreateMap<User, UserDTO>().ReverseMap();    
            CreateMap<Media, MediaDTO>().ReverseMap();
        }
    }
}
