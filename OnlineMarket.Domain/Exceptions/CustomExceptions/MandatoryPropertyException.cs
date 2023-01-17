using OnlineMarket.Domain.Exceptions.GeneralExceptions;

namespace OnlineMarket.Domain.Exceptions.CustomExceptions;

public class MandatoryPropertyException : BadRequestException
{
    public MandatoryPropertyException(string propertyName) : base(String.Format( "field {0} is mandatory",propertyName))
    {
        
    }
}