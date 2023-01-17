namespace OnlineMarket.Domain.Exceptions.GeneralExceptions;

public class NotFoundException :ApplicationExceptionBase
{
    public NotFoundException(string message) : base(message)
    {
        HttpStatusCode = System.Net.HttpStatusCode.NotFound;
    }
}