namespace Clinic.Api.Middlwares
{
    public class AppException : Exception
    {
        public int ErrorId { get; }
        public string Description { get; }

        public AppException(int errorId, string description) : base(description)
        {
            ErrorId = errorId;
            Description = description;
        }
    }
}
