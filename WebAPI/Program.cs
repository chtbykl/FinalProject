
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public class Program
    {
        

        public Program(IConfiguration configuration)
        {
            

        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()) // bu ben kendi yazd���m konfig�rasyon s�n�f�n� kullanaca��m anlam�na geliyor
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModele());
                });

            //AOP
            //Autofac,Ninject, CastleWindsor, StructreMap,LightInject, DryInject
            //builder.Services.AddSingleton<IProductService, ProductManager>(); // birisi senden IProductService isterse sen ona arka planda bir ProductManager olu�tur ve ona ver
            // bu singleton sayesinde referans� bir milyon tane client te kullansa hepsine ayn� referans verilir b�ylece bir milyon tane referans �retmek zorunda kalmay�z
            //tabi bu sigleton'u productmanager da veri(data) tutmuyorsak bir referans olu�tururuz
            // �rne�in product managerda bir m��teri sepeti datas� tutuluyorsa, kim ne ekliyosa ayn� sepete eklenir, herkesin sepeti birbirine girer
            //builder.Services.AddSingleton<IProductDal, EfProductDal>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //biz asp.net e diyoruz ki: bu sistemde JWT kullan�lacak haberin olsun
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); // buna middleWave deniyor, middleWave: asp.net ya�am d�ng�s�nde hangi uygulamalar�n s�ras�yla devreye girece�ini s�yl�yoruz
            
            app.UseAuthorization();
          
            app.MapControllers();

            app.Run();
        }
    }
}
