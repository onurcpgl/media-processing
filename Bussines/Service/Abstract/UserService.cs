using AutoMapper;
using Bussines.DTO;
using Bussines.Service.Concrete;
using DataAccess.Repositories.Concrete;
using Domain.Entities;
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
        private readonly IMediaService _mediaService;
        public UserService(IGenericRepository<User> genericRepository,IMapper mapper,IMediaService mediaService)
        {
            _genericRepository = genericRepository;
            _mediaService = mediaService;
            _mapper = mapper;
        }
        public async Task<bool> SaveUser(UserDTO userDto)
        {
            if(userDto.FormFiles != null)
            {
                var resultMedia = await _mediaService.SaveMedias(userDto.FormFiles);
                var mapUser = _mapper.Map<User>(userDto);
                mapUser.Medias = new List<Media>((IEnumerable<Media>)resultMedia);
                var result = await _genericRepository.Add(mapUser);
                return result;

            }
            else
            {
                var mapUser = _mapper.Map<User>(userDto);
                var result = await _genericRepository.Add(mapUser);
                return result;
            }
            
        }
    }
}
