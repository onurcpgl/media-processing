using AutoMapper;
using Bussines.DTO;
using Bussines.Service.Concrete;
using DataAccess.Repositories.Concrete;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Service.Abstract
{
    public class ProductService : IProductService
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IMediaService _mediaService;
        public ProductService(IGenericRepository<Product> genericRepository, IMapper mapper, IConfiguration config, IMediaService mediaService)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _config = config;
            _mediaService = mediaService;
        }
       
        public async Task<bool> SaveProduct(ProductDTO productDto)
        {
            if (productDto.FormFile != null)
            {
                var todayDate = DateTime.Now.ToString("yyyyMMdd");
                var todayTime = DateTime.Now.ToString("HHmmss");
                var rootPath = _config["MediaStorage:FileRootPath"];
           
                var filePath = $"myapp/{todayDate}/{todayTime}";
                var fullPath = $"{rootPath}/{filePath}";
                var filenamehash = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
                Media media = new Media
                {
                    RealFilename = productDto.FormFile.FileName,
                    EncodedFilename = filenamehash,
                    FilePath = filePath,
                    RootPath = rootPath,
                    AbsolutePath = $"{filePath}/{filenamehash}{Path.GetExtension(productDto.FormFile.FileName)}",
                    Size = productDto.FormFile.Length,
                    Deleted = false,
                };
                var resultMedia = await _mediaService.SaveMedia(media);
                var mapProduct = _mapper.Map<Product>(productDto);
                mapProduct.Media = resultMedia;
                var result = await _genericRepository.Add(mapProduct);
                return result;
            }
            else
            {
                var mapProduct = _mapper.Map<Product>(productDto);
                var result = await _genericRepository.Add(mapProduct);
                return result;
            }

        }
    }
}
