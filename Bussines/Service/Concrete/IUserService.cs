using Bussines.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Service.Concrete
{
    public interface IUserService
    {
        Task<bool> SaveUser(UserDTO userDto);
    }
}
