using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string[] errors) : base("Multiple errors occurred. See error details.")
        {
            Errors = errors;
        }

        public string[] Errors { get; set; }
    }

    public class ValidationErrorException : Exception
    {

        public ValidationErrorException(string[] errors) : base("Multiple errors in Validation occurred. See error details.")
        {
            Errors = errors;
        }

        public string[] Errors { get; set; }
    }

    public class ErrorMappingException : Exception
    {
        public ErrorMappingException() : base("Error was Happen while Mapping") { }
    }

    public class NoDataFoundException : Exception
    {
        public NoDataFoundException() : base("No Data Found") { }

        public NoDataFoundException(string message) : base(message) { }
    }

    public class SaveChangesFailedException : Exception
    {
        public SaveChangesFailedException() : base("Failed to save changes to the database.") { }

        public SaveChangesFailedException(string message) : base(message) { }

        public SaveChangesFailedException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base($"Data Not Found") { }

        public EntityNotFoundException(string message) : base($"{message} Not Found") { }
    }

    public class SocketException : Exception
    {
        public SocketException(string message) : base(message) { }
    }

    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message) : base($"{message} already exists.") { }
    }

    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string authority) : base($"You are not have the authoriy for '{authority}'") { }
    }

    public class UnValidatedAccessException : Exception
    {
        public UnValidatedAccessException(string provider) : base($"{provider} not validated. Please check your inbox for a validation link.") { }
    }

    public class UnauthenticatedException : Exception
    {
        public UnauthenticatedException() : base($"Username or password is incorrect") { }
    }

    public class InvalidOperationsException : Exception
    {
        public InvalidOperationsException(string message) : base(message) { }
    }
}
