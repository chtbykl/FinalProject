using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        // interface methodları defoult publictir. ama isterface sınıfı default internaldır.

        List<ProductDetailDTO> GetProductDetails();
    }
}//code Refactoring
