using OnlineMarket.Domain.Exceptions.GeneralExceptions;

namespace OnlineMarket.Domain.Exceptions.CustomExceptions;

public class MaxLengthException : BadRequestException
{
    public MaxLengthException(string propertyName, int length) : base(string.Format(" The length of {0} cannot be more than {1} ",propertyName,length))
    {
        
    }
}