namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } //anlamsız karakterlerden oluşan bir anahtar değeridir
        public DateTime Expiration { get; set; } // token'ın bitiş zamanı (verilen anahtarın bir süresi vardır)
    }
}
