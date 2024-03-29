﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //context: veri tabanı tabloları ile kendi klaslarımızı ilişkilendirdiğimiz class'ın ta kendisidir.
    internal class NorthwindContext: DbContext // dbcontext: entityframework ile bu base sınıf gelir. bunu implemente ettiğimzde bu sınıfın bir context sınıfı olduğunu işaretler
    {
        //override onconfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // bu method senin projen hangi veritabanı ile ilişkilidir sorusunu belirttiğimz yerdir.
        {
            //base.OnConfiguring(optionsBuilder); // bu dbcontextin onconfiguring'ini çalıştırır oyüzden bunu sildik. buna ihtiyacımız yok
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Northwind; Trusted_Connection = true");  // sql server kullanacağımızı söyledik. sql server'ımızın nerede olduğunu parantez içinde söyledik, buna connectionstring(bağlantı) ifadesi denir.
        }

        public DbSet<Product> Products { get; set; } // hangi clas hangi tabloya karşılık geliyor onu tanımlıyoruz. product clası, products tablosuna karşılık geliyor.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
