
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

            builder.Services.AddSingleton<IProductService,ProductManager>(); // birisi senden IProductService isterse sen ona arka planda bir ProductManager olu�tur ve ona ver
            // bu singleton sayesinde referans� bir milyon tane client te kullansa hepsine ayn� referans verilir b�ylece bir milyon tane referans �retmek zorunda kalmay�z
            //tabi bu sigleton'u productmanager da veri(data) tutmuyorsak bir referans olu�tururuz
            // �rne�in product managerda bir m��teri sepeti datas� tutuluyorsa, kim ne ekliyosa ayn� sepete eklenir, herkesin sepeti birbirine girer
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
