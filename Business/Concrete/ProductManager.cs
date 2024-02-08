using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<Product> GetById(int id) 
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=> p.ProductId == id));
        }
        public IResult add(Product product)
        {
            //magic strings
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.InvalidProductName);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),"ürünler listelendi") ;
        }

        public IDataResult<List<Product>> GetByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=> p.CategoryId == id),"ürünler kategoriye göre listelendi");
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal minPrice, decimal maxPrice)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice),"ürünler fiyatına göre listelendi");
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetProductDetails(),"ürünler ayrıntılarıyla birlikte listelendi");
        }
    }
}
