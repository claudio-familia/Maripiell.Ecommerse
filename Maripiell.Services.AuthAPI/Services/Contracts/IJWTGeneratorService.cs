namespace Maripiell.Services.AuthAPI.Services.Contracts
{
    public interface IJWTGeneratorService
    {
        Task<string> GenerateTokenAsync(string token);
    }
}
