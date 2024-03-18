namespace Core.Utilities.Security.JWT
{
    public class TokenOptions // apideki appsettings.json içindeki tokenoptions nesnesine karşılık kullanacağımız bir sınıf oluşturduk
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
