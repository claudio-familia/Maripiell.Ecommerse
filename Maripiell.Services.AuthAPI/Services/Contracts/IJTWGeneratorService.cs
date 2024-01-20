namespace Maripiell.Services.AuthAPI.Services.Contracts
{
    public interface IJTWGeneratorService
    {
        Task<string> GenerateTokenAsync(string token);
    }
}
