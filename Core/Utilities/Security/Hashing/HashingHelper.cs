using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, // bir password veriyoruz ve dışarıya passwordHash ve passwordSalt gönderiyoruz
            out byte[] passwordSalt) // asp.netin cryptography sınıfından fayfdalanıyoruz
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; // her kullanıcı için bir key oluşturur ve bu şifrelenmiş bir passwordun geri çözümlenmesi için önemlidir
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // şifrenin byte array karşılığını aldık ve bunu şifrenin hashine çevirdik
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash,
             byte[] passwordSalt) // bu sınıf gönderdiğimiz şifreyi tekrar aynı yöntemle oluştursaydı, gönderilen salt ve hash gibi şeyler olurmuydu onu doğruluyoruz
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) // passwordsaltı gönderiyoruz ki şifreyi tekrar çözümleyip doğrulama yapabilsin
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // hesaplanan hash tamamen yukarıda verdiğimiz salt kullanılarak yapılıyor.
                for (int i = 0; i < computedHash.Length; i++) 
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
