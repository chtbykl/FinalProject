using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
namespace Business.BusinessAspects.Autofac
{
    // bu class JWT için
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; // her bir http isteği(her bir istek yapan kişi) için bir httpcontext'i oluşur, herkese bir tane bir thread oluşur

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); // verilen metni belirttiğimiz karakterden bölüp bir string[] haline getiriyor
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); // autofacten yaptığımız gibi bir interfacein somutunu veriyor
            //IHttpContextAccessor asp.net core'un içerisinden gelen bir yapı, aynı IConfiguration yapısı gibi
        }

        protected override void OnBefore(IInvocation invocation) // onBerfore metoddan önce çalıştır demek ve methodInterception'dan geliyor
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles(); // o anki kullanıcının claim rollerini bul diyoruz, yani metoda erişmek isteyen kullanıcı
            foreach (var role in _roles) // bizim gönderdiğimz rolleri gez
            {
                if (roleClaims.Contains(role)) // eğer bizim gönderdiğimiz rollere bu kullanıcıda sahip ise
                {
                    return; // return et, yani kullanıcı hangi metodu kullanmak istiyorsa izin ver yani metodu çalıştırmaya devam et
                }
            }
            throw new Exception(Messages.AuthorizationDenied); // kullanıcının rolleri bizim istediğimz roller değilse hata fırlat
        }
    }
}
