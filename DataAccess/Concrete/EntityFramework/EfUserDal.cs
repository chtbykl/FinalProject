using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims // operationClaimler ile
                             join userOperationClaim in context.UserOperationClaims // UserOperationCalimlere join atıyor (iki tabloyu birleştiriyor)
                             on operationClaim.Id equals userOperationClaim.OperationClaimId //operaitonClaim'in Id'si ile UserOperationClaim'in OperationClaimId'si ni eşleştirerek iki tabloyu birleştiriyor
                             where userOperationClaim.UserId == user.Id // sonrabirleştirilen tablodan Id'si benim gönderdiğim User Id'sine eşit olanı buluyor
                             select new OperationClaim { 
                                 Id = operationClaim.Id, 
                                 Name = operationClaim.Name 
                             };
                return result.ToList();

            }
        }
    }
}
