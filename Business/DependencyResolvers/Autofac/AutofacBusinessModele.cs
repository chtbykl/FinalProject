using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModele:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();// birisi senden IProductService isterse sen ona arka planda bir ProductManager oluştur ve ona ver
            // bu singleInstance sayesinde referansı bir milyon tane client te kullansa hepsine aynı tek bir referans verilir böylece bir milyon tane referans üretmek zorunda kalmayız        
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            // program.cs deki builder konfigürasyonundan hiç bir farkı yok bunun da sadece yazımı değişik
        }
    }
}
