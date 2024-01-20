using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maripiell.Services.AuthAPI.Domain.Models
{
    [Table("Roles")]
    public class Role: IdentityRole<int>
    {
    }
}
