﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maripiell.Services.AuthAPI.Domain.Models
{
    [Table("UserTokens")]
    public class UserToken: IdentityUserToken<int>
    {
    }
}