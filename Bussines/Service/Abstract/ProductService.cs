using AutoMapper;
using Bussines.DTO;
using Bussines.Service.Concrete;
using Domain.Entities;
using Domain.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Service.Abstract
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<User> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
       
        public Task<bool> SaveProduct(ProductDTO productDto)
        {
            throw new NotImplementedException();
        }
    }
}
