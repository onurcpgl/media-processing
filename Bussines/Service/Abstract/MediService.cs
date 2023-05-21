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
    public class MediService : IMediaService
    {   
        private readonly IGenericRepository<Media> _genericRepository;
        private readonly IMapper _mapper;
        public MediService(IGenericRepository<Media> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;   
        }
        public Task<bool> SaveMedia(MediaDTO mediaDto)
        {
            throw new NotImplementedException();
        }
    }
}
