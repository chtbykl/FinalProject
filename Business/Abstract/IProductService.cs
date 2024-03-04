using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal minPrice, decimal maxPrice);
        IDataResult<List<ProductDetailDTO>> GetProductDetails();
        IDataResult<Product> GetById(int id);
        IResult add(Product product);
        IResult update(Product product);
    } // Restfull --> HTTP protokolü-->
}
