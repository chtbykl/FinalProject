using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
