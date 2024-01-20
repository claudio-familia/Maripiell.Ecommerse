using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maripiell.Services.AuthAPI.Domain.Models
{
    [Table("Users")]
    public class User: IdentityUser<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Country { get; set; }
    }
}
