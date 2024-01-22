using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal:IProductDal
    {
        private List<Product> _products;
        public InMemoryProductDal()
        {
            //fake database, oracle, sql, postgre,mysql
            _products = new List<Product>
            {
                new Product{CategoryId = 1,ProductId = 1,ProductName = "mercimekli pilav",UnitPrice = 50,UnitsInStock = 20},
                new Product{CategoryId = 1,ProductId = 2,ProductName = "prinç pilavı",UnitPrice = 40,UnitsInStock = 15},
                new Product{CategoryId = 2,ProductId = 3,ProductName = "yoğurtlu çorba",UnitPrice = 30,UnitsInStock = 25},
                new Product{CategoryId = 2,ProductId = 4,ProductName = "ezogelin çorbası",UnitPrice = 25,UnitsInStock = 30}
            };
        }
        public List<Product> GetAll(Expression<Func<Product,bool>> filter=null)
        {
            return _products;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;

            //linqsiz döngüler ile yapılır
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //.net LİNQ dil ile tümleşik sorgulama

            productToDelete = _products.SingleOrDefault(p=> p.ProductId == product.ProductId);
            //productToDelete = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            //productToDelete = _products.First(p => p.ProductId == product.ProductId); bu üç kullanımda birbirine eşit. aynı şeyi yaparlar
            // bu ifadeler tek bir eleman döndürür where o ürünlerin listesini döndürür

            _products.Remove(productToDelete);
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün ıd'sine sahip ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
