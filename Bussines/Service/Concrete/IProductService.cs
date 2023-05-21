using Bussines.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Service.Concrete
{
    public interface IProductService
    {
        Task<bool> SaveProduct(ProductDTO productDto);
    }
}
