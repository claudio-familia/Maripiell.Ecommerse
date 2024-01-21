using Microsoft.AspNetCore.Identity;

namespace Maripiell.Services.AuthAPI.Domain.Common
{
    public static class AuthIdentityErrorResult
    {
        public static string ToString(IEnumerable<IdentityError> errors)
        {
            string response = "";

            foreach (var error in errors)
            {
                response += $"code: {error.Code}, message: {error.Description}";
            }
            
            return response;
        }
    }
}
