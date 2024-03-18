using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    //biz bu sisteme diyoruz ki:sen bir JWT sistemini yöneticeksin, senin anahtarın securityKey'dir. şifreleme algoritman da HmacSha512 dir.
    public class SigningCredentialsHelper
    {

        //JWT oluşturulabilmek için verdiğimiz credential'ı, yani securityKey'i, imzalayıp bize geri döndürüyor olucak
        // mesela bir sisteme girmek için kullanıcı adı-parola bir credential'dır.Burada da bu sistemi kullanabilmek için Elimizde olan credential, bir securityKey'dir.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);

            // asp.net'e diyoruz ki: sen bir hashing işlemi yapıcaksın bu işlemi yapabilmek için anahtar olarak verdiğim security key'i kullan
            // şifreleme olarak da güvenlik algoritamalarından HmacSha512'yi kullan
        }
    }
}
