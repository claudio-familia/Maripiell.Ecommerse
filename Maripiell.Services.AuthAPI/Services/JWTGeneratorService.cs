using Maripiell.Services.AuthAPI.Services.Contracts;

namespace Maripiell.Services.AuthAPI.Services
{
    public class JWTGeneratorService : IJWTGeneratorService
    {
        public Task<string> GenerateTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
