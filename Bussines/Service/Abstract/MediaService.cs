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
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace Bussines.Service.Abstract
{
    public class MediaService : IMediaService
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private readonly IGenericRepository<Media> _genericRepository;
        private readonly IConfiguration _config;

        public MediaService(IGenericRepository<Media> genericRepository,IConfiguration config)
        {
            _genericRepository = genericRepository;
            _config = config;

        }
        public async Task<Media> SaveMedia(IFormFile FormFile)
        {
            var todayDate = DateTime.Now.ToString("yyyyMMdd");
            var todayTime = DateTime.Now.ToString("HHmmss");
            var rootPath = _config["MediaStorage:FileRootPath"];

            var filePath = $"myapp/{todayDate}/{todayTime}";
            var fullPath = $"{rootPath}/{filePath}";
            var filenamehash = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
            Media media = new Media
            {
                RealFilename = FormFile.FileName,
                EncodedFilename = filenamehash,
                FilePath = filePath,
                RootPath = rootPath,
                AbsolutePath = $"{filePath}/{filenamehash}{Path.GetExtension(FormFile.FileName)}",
                Size = FormFile.Length,
                Deleted = false,
            };
            var resultMedia = await _genericRepository.AddModel(media);
            return resultMedia;
        }

        public async Task<ICollection<Media>> SaveMedias(IEnumerable<IFormFile> formFiles)
        {
            var mediaList = new HashSet<Media>();

            Parallel.ForEach(formFiles, item =>
            {
                var todayDate = DateTime.Now.ToString("yyyyMMdd");
                var todayTime = DateTime.Now.ToString("HHmmss");
                var rootPath = _config["MediaStorage:FileRootPath"];

                var filePath = $"myapp/{todayDate}/{todayTime}";
                var fullPath = $"{rootPath}/{filePath}";
                var filenamehash = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());

                var media = new Media
                {
                    RealFilename = item.FileName,
                    EncodedFilename = filenamehash,
                    FilePath = filePath,
                    RootPath = rootPath,
                    AbsolutePath = $"{filePath}/{filenamehash}{Path.GetExtension(item.FileName)}",
                    Size = item.Length,
                    Deleted = false
                };
                

                mediaList.Add(media);
            });


            var resultMediaList = await _genericRepository.AddRangeAsync(mediaList);

            return resultMediaList;

        }
    }
}
