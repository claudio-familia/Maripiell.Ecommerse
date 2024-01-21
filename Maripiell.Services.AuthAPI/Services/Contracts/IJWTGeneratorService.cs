using Maripiell.Services.AuthAPI.Domain.Models;

namespace Maripiell.Services.AuthAPI.Services.Contracts
{
    public interface IJWTGeneratorService
    {
        string GenerateToken(User token);
    }
}
