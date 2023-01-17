

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineMarket.WebApi.Controllers.Base;

[ApiController]
[Route("[controller]")]

public abstract class OnlineMarketBaseControllers : ControllerBase
{
    private IMediator _mediator ;
    
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
  

  
}