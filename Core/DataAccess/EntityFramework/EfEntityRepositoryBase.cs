using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity, new() 
        where TContext : DbContext, new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) //burada parametre olarak göndereceğimiz şey bir lamda(koşul, şart(p=> p.Id ==2))...
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>()
                        .ToList() // filtre verilmemişse, product tablosuna yerleş ve bütün productları listele
                    : context.Set<TEntity>().Where(filter)
                        .ToList(); // filtre verilmişse o filtreyi where komutu ile uyguluyoruz
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); //context.Set<Product>() : bu bizim ürünler tablomuz olmuş oluyor. yani bir product listesi aslında
            }
        }

        public void Add(TEntity entity)
        {
            //IDispossable pattern implementation of c#
            using (TContext context = new TContext())// using içerisinde yazdığımız nesneler garbagecollector'e geliyor ve beni bellekten at diyor. çünkü garbagecollector belli zamanlarda bellekteki gereksiz referansları atmaya gelir.
            // bu using sayesinde kullanıldıktan sonra işi biten nesne anında garbageCollector tarafından atılıyor. böylece bellekte gereksiz yer kaplamıyor.
            //yani northwinContext işi bitince atılacak. bu hareketle daha performanslı bir ürün geliştiririz.
            {
                var addedEntity = context.Entry(entity); // bu referansı yakalama işlemidir.
                addedEntity.State = EntityState.Added;//addedentity, aslında eklenecek bir nesne, onu ekle
                context.SaveChanges();// yapılan değişiklikleri gerçekleştir
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
