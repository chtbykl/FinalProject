
using Core.Entities;
using System.Linq.Expressions;


namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T: class, IEntity, new()
        // where T: T yi sınırlandırır ne olabileceğini gösterir.
        // class: t nin bir referans tip olabileceğini gösterir yani int decimal bool gibi değer tipler engellenir.
        //IEntity: bu ifade, sadece IEntity'nin kendisi veya IEntity interface'ini implemente eden  sınıflar kullanılabilir demek oluyor. bu da sadece veri tabanı nesnelerimizin kullanılabileceği anlamındadır.
        // ama biz soyut bir nesne olan IEntity interface'i kullanılsın istemiyoruz. onun için new() ifadesini kullanırız
        // new() : newlenebilir sınıflar kullanılsın demek, interfaceler asla newlenemez, bu da interfaceler kullanılmasın, classlar kullanılabilsin demek.
        //generic constrait (generik kısıt): t tipindeki değişkene int string gibi tiplerde verilebiliyor. bunu sınırlandırabilmeliyiz. T sadece veri tabanı nesnesi olmalı, yani IEntity'i implemente eden nesneler olmalı
    {



        List<T> GetAll(Expression<Func<T,bool>> filter = null); // exression ile filtre verebiliriz. buna delege denir.
        //(p=> p.CategoryId ==2) buna bir expression denir. bu şartı verebilmemiz için expression kullanırız.
        // filter=null demek, filtre vermeyebilirsin de demektir.
        //eğer filtre vermemişsek tüm datayı istiyoruz demektir

        T Get(Expression<Func<T, bool>> filter);
        // List<T> GetByCategory(Category category); buraya artık ihtiacımız yok çümkü en yukarıda zaten kategori filtresi ekleyip istediğimiz kategoridekileri de görebiliyoruz..
       
        void Add(T entity);
       
        void Delete(T entity);
        
        void Update(T entity);
    }
}
