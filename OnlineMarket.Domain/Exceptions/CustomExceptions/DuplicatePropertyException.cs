namespace OnlineMarket.Domain.Exceptions.CustomExceptions;

public class DuplicatePropertyException : BadImageFormatException
{
    public DuplicatePropertyException(string propertyName) :base(String.Format( "field {0} is duplicate",propertyName))
    {
        
    }
}