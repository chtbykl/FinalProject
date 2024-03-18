using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } // APImizdeki appsettings.json dosyamızı okumamıza yarıyor
        private TokenOptions _tokenOptions; // appsettings.json dosyasındaki tokenoptions nesnesinin değerini tutabilmek için böyle bir nesne oluşturduk
        private DateTime _accessTokenExpiration; // accessToken ne zaman geçersiz hale gelicek onun zamanını tutuyor
        public JwtHelper(IConfiguration configuration) // enjekte edilen bu Iconfiguration nesnesi sayesinde .NET bize apinin kanfigürasyon(appsettings.json) nesnesini bize veriyor. asp.net bize otomatik appsettings.json'ı vericektir burada
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //appsettings.jsondaki tokenOptions isimli section'ı alıp, oluşturduğumuz nesneye dönüştürüp(mapleyip), o nesne tipinde tutuyoruz

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); // tokenOptions daki accestokenexpitation değerini yani 10 yolluyoruz
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); // daha önce yazdığımız güvenlik anahtar oluşturucusuna tokenoptions'daki securitykey'i yolluyoruz
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); // hangi algoritama ve hangi güvenlik anahtarını kullanacağımızı verip bir credential değeri alıyoruz
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        { // var olan bir sınıfa biz yeni methodlar veya özellikler ekleyebiliyoruz. buna extension deniyor yani genişletmek
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}"); // dolar işareti string tipindeki iki değeri art arda toplar
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
