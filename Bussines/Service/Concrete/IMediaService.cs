using Bussines.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Service.Concrete
{
    public interface IMediaService
    {
        Task<Media> SaveMedia(IFormFile FormFile);
        Task<ICollection<Media>> SaveMedias(ICollection<IFormFile> formFiles);

    }
}
