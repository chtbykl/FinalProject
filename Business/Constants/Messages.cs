using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string InvalidProductName = "Ürün adı geçersiz";
        public static string MaxProductCountOfCategory = "bu ürünün kategorisinde maximum ürün sayısına ulaşıldı";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductNameAlreadyExists = "aynı isimde ürün zaten mevcut";
        public static string MaxCategoryCount = "Maximum kategori sınırına ulaşıldı. Kategori sayısı 15'ten büyükse ürün eklenemez";
        public static string AuthorizationDenied = "Bu işlemi gerçekleştirebilmek için yetkiniz bulunmuyor";
        public static string UserRegistered = "Yeni Kullanıcı kayıt edildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Erişim anahtarı(Token) oluşturuldu";
    }
}
