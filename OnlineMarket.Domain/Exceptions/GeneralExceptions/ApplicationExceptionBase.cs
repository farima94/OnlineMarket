using System.Net;

namespace OnlineMarket.Domain.Exceptions.GeneralExceptions;

public class ApplicationExceptionBase : Exception
{
    public HttpStatusCode HttpStatusCode { get; set; }


    public ApplicationExceptionBase(string message) :base (message)
    {
        
    }
}