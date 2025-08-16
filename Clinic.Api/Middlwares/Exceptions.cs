namespace Clinic.Api.Middlwares
{
    public class Exceptions
    {
        public class NotFoundException : AppException
        {
            public NotFoundException(int errorId, string description)
                : base(errorId, description) { }
        }

        public class ValidationException : AppException
        {
            public ValidationException(int errorId, string description)
                : base(errorId, description) { }
        }

        public class ConflictException : AppException
        {
            public ConflictException(int errorId, string description)
                : base(errorId, description) { }
        }

        public class UnAuthorizedException : AppException
        {
            public UnAuthorizedException(int errorId, string description) 
                : base(errorId, description) { }
        }

        public class ClaimNotFound : AppException
        {
            public ClaimNotFound(int errorId, string description)
                : base(errorId, description) { }
        }

        public class InvalidModelData : AppException
        {
            public InvalidModelData(int errorId, string description)
                : base(errorId, description) { }
        }
    }
}
