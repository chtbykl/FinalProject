using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user); // extradan bir operasyon koyduk çünkü burada bir join atacağız
    }
}//code Refactoring
