using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        //calimPrincipal bir kişinin claimlerine ulaşmak için, o anki gelen JWT ile gelen kişinin calimlerine ulaşmak için .NET'de olan bir class
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList(); // soru işareti null olabileceği anlamına gelir, örneğin henüz bir claim oluşturmadıysa boş olabilir
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
