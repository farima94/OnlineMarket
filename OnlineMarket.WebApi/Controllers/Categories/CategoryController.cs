using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Application.Categories.Commands;
using OnlineMarket.Application.Categories.Queries;
using OnlineMarket.Application.Common.Dto.Categories;
using OnlineMarket.WebApi.Controllers.Base;

namespace OnlineMarket.WebApi.Controllers.Categories;

public class CategoryController : OnlineMarketBaseControllers
{

    
    // CategoryList
    [HttpGet]
    public async Task<List<CategoryDto>> Get([FromQuery]GetAllCategoryListQuery request)
    {
        return await Mediator.Send(request);
        
    }
    [HttpGet("{id}")]
    public async Task<CategoryDto> GetById(int id)
    {
        return await Mediator.Send(new GetAllCategoryListByIdQuery()
        {
          CategoryId= id
        });
        
    }

    
    //Create Category
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Add([FromForm]AddCategoryCommand request)
    {
        var categoryDto=await Mediator.Send(request);
        return CreatedAtAction(nameof(GetById),new{Id=categoryDto.CategoryId},categoryDto);

    }
    
    
    //Update Category 

  /*  [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id,[FromBody] UpdateCategoryCommand command)
    {
        if (commadn.categoryId!=id)
        {
            
        }
        await Mediator.Send(commadn);
        return NoContent();
    }*/

}