using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maripiell.Services.AuthAPI.Domain.Models
{
    [Table("UserLogins")]
    public class UserLogin: IdentityUserLogin<int>
    {
    }
}
