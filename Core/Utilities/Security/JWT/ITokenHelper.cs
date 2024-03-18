using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper // ilgili kullanıcının claimlerini içerecek bir token üretecek
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
