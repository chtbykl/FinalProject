using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet: insanların kodlarının ortak koyulduğu ve yönetildği yer
    public class EfProductDal : IProductDal
    {
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null) //burada parametre olarak göndereceğimiz şey bir lamda(koşul, şart(p=> p.Id ==2))...
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null
                    ? context.Set<Product>()
                        .ToList() // filtre verilmemişse, product tablosuna yerleş ve bütün productları listele
                    : context.Set<Product>().Where(filter)
                        .ToList(); // filtre verilmişse o filtreyi where komutu ile uyguluyoruz
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); //context.Set<Product>() : bu bizim ürünler tablomuz olmuş oluyor. yani bir product listesi aslında
            }
        }

        public void Add(Product entity)
        {
            //IDispossable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())// using içerisinde yazdığımız nesneler garbagecollector'e geliyor ve beni bellekten at diyor. çünkü garbagecollector belli zamanlarda bellekteki gereksiz referansları atmaya gelir.
            // bu using sayesinde kullanıldıktan sonra işi biten nesne anında garbageCollector tarafından atılıyor. böylece bellekte gereksiz yer kaplamıyor.
            //yani northwinContext işi bitince atılacak. bu hareketle daha performanslı bir ürün geliştiririz.
            {
                var addedEntity = context.Entry(entity); // bu referansı yakalama işlemidir.
                addedEntity.State = EntityState.Added;//addedentity, aslında eklenecek bir nesne, onu ekle
                context.SaveChanges();// yapılan değişiklikleri gerçekleştir
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
