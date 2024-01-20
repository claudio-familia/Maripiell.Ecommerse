using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maripiell.Services.AuthAPI.Domain.Models
{
    [Table("UserClaims")]
    public class UserClaim: IdentityUserClaim<int>
    {
    }
}
