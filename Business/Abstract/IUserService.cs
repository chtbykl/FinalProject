using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user); // kullanıcı claimlerini çek
        void Add(User user); // kullanıcı ekle
        User GetByMail(string email); // email e göre kullanıcı çek
    }
}
