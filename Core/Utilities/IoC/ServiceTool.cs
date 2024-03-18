using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        // webapi de veya autofac te oluşturduğumuz injection'ları oluşturabilmemize yarıyor
        // bundan sonra istediğimz herhangi bir interface'in servisteki karşılığını bu tool ile alabiliyoruz
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) // .Net'in IserviceCollection yani servislerini al, ve onları build et
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
