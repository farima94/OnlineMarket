using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineMarket.Application.Common.Dto.Categories;
using OnlineMarket.Domain.Exceptions.GeneralExceptions;
using OnlineMarket.Domain.Interfaces;

namespace OnlineMarket.Application.Categories.Commands;

public class AddCategoryCommand : IRequest<CategoryDto>
{
    public IFormFile Files { get; set; }

    public string CategoryName { get; set; }

    public string Description { get; set; }
}


public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, CategoryDto>
{
    private readonly IApplicationDbContext _context;
    
    private readonly IFileService _fileServiceCommunicator;

    private readonly ICategoryDomainService _categoryDomainService;
    

    public AddCategoryHandler(IApplicationDbContext context, IFileService fileServiceCommunicator,ICategoryDomainService categoryDomainService)
    {
        _fileServiceCommunicator = fileServiceCommunicator;
        _categoryDomainService = categoryDomainService;
        _context = context;
    }
    
    public async Task<CategoryDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
    
        var imageUrl= await _fileServiceCommunicator.SaveFiles(request.Files);
        
        var category=await  _categoryDomainService.CreateCategoryAsync(imageUrl, request.CategoryName, request.Description);
        
       _context.Categories.Add(category);
       await _context.SaveChangesAsync(cancellationToken);
       
       var result = new CategoryDto() 
       {
           CategoryId = category.Id,
           ImageUrl = category.ImageUrl,
           Name = category.Name,
           Description = category.Description
       }; 


     

      return result;
    }
}