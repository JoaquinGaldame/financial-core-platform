namespace Financial.Domain.Exceptions;
// Representa reglas del negocio.
public sealed class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }
}