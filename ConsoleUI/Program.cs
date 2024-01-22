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
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            
            foreach (Product p in productManager.GetByUnitPrice(50,100))
            {
                Console.WriteLine(p.ProductName);
            }

        }
    }
}
