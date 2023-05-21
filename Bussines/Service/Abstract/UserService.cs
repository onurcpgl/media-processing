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
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public Task<bool> SaveUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
