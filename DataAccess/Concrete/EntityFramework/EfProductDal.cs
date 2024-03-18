using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet: insanların kodlarının ortak koyulduğu ve yönetildği yer
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDTO> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products //ürünler tablosundaki ürünler ile
                             join c in context.Categories // kategoriler tablosundaki kategorileri joinle(birleştir)
                             on p.CategoryId equals c.CategoryId // neye göre? bu verdiğim kategroi ıdlerinin eşit olma şartına göre
                             select new ProductDetailDTO
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock,

                             }; //peki hangi kolonları istiyosun? birbirine karşılık gelen şu kolonları istiyorum...
                return result.ToList();
            }
        }
    }
}
