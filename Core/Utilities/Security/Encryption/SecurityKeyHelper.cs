using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    // işin içinde şifreleme olan sistemlerde bizim herşeyi byte[] formatında vermemiz gerekiyor
    // 
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); // securityKeyi, byte[] formatına dönüştürüyoruz ve bu formatı gönderip karşılığında simetrikKey alıyoruz
        }               // bu anahtarlar simetrik ve asimetrik olarak ayrılır
    }
}
