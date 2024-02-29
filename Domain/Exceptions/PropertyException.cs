namespace Domain.Exceptions;

public class PropertyException : Exception
{
    public PropertyException(string propertyName) :
        base($"{propertyName} is not a property") { }
    public override string Message => "Property is invalid";
}
