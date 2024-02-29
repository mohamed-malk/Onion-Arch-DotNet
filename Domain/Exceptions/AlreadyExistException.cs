namespace Domain.Exceptions;

public sealed class AlreadyExistException : Exception
{
    public AlreadyExistException(string entityName) :
    base($"this {entityName} already exist")
    { }
}
