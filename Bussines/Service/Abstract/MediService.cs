using AutoMapper;
using Bussines.DTO;
using Bussines.Service.Concrete;
using Domain.Entities;
using DataAccess.Repositories.Concrete;
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
        
        public MediService(IGenericRepository<Media> genericRepository)
        {
            _genericRepository = genericRepository;
            
        }
        public Task<Media> SaveMedia(Media media)
        {
            var result = _genericRepository.AddModel(media);
            return result;
        }
    }
}
