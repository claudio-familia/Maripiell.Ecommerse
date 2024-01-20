using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maripiell.Services.AuthAPI.Domain.Models
{
    [Table("RoleClaims")]
    public class RoleClaim: IdentityRoleClaim<int>
    {
    }
}
