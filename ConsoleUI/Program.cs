using System.Net.Http.Headers;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        //SOLID
        //IoC
        static void Main(string[] args)
        {
            ProductsTest();

            //CategoriesTest();



        }

        private static void CategoriesTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var c in categoryManager.GetAll())
            {
                Console.WriteLine(c.CategoryName);
            }

            Console.WriteLine(categoryManager.GetById(3).CategoryName) ;
        }

        private static void ProductsTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var p in productManager.GetProductDetails())
            {
                Console.WriteLine(p.ProductName + " / " + p.CategoryName );
            }
        }
    }
}
