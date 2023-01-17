namespace OnlineMarket.Domain.Exceptions.GeneralExceptions;

public class BadRequestException : ApplicationExceptionBase
{
    public BadRequestException(string message) : base(message)
    {
        HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
    }
}