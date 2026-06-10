
namespace Financial.Application.common.Exceptions;

// Representa errores de casos de uso.
public sealed class ApplicationException : Exception
{
    public ApplicationException(string message) : base(message)
    {
    }

    public ApplicationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}