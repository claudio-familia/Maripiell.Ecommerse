namespace Maripiell.Common.Common.Domain.Common
{
    [Serializable]
    public class CustomError : Exception
    {
        public CustomError(string message) : base(message)
        {
        }
    }
}
