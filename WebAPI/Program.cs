
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<IProductService,ProductManager>(); // birisi senden IProductService isterse sen ona arka planda bir ProductManager oluþtur ve ona ver
            // bu singleton sayesinde referansý bir milyon tane client te kullansa hepsine ayný referans verilir böylece bir milyon tane referans üretmek zorunda kalmayýz
            //tabi bu sigleton'u productmanager da veri(data) tutmuyorsak bir referans oluþtururuz
            // örneðin product managerda bir müþteri sepeti datasý tutuluyorsa, kim ne ekliyosa ayný sepete eklenir, herkesin sepeti birbirine girer
            builder.Services.AddSingleton<IProductDal, EfProductDal>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
