using System.Globalization;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Application.Common.Dto.Categories;
using OnlineMarket.Domain.Entities;
using OnlineMarket.Domain.Exceptions.GeneralExceptions;
using OnlineMarket.Domain.Interfaces;

namespace OnlineMarket.Application.Categories.Commands;

public class UpdateCategoryCommand : IRequest<CategoryDto>
{
    public IFormFile? files { get; set; }
    public int CategoryId { get; set; }
    
    public string?  CategoryName { get; set; }
    
    public string? Description { get; set; }
}

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    private readonly IApplicationDbContext _context;
    
    private readonly IFileService _fileService;

    private readonly ICategoryDomainService _categoryDomainService;

    public UpdateCategoryHandler(IApplicationDbContext context, IFileService fileService, ICategoryDomainService categoryDomainService)
    {
        _context = context;
        _fileService = fileService;
        _categoryDomainService = categoryDomainService;
    }
    
    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category =await _context.Categories.Where(w => w.Id == request.CategoryId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (category==null)
        {
            throw new NotFoundException("Category not found");
        }

        if (request.CategoryName!= null)
        {
            await _categoryDomainService.UpdateCategoryNameAsync(category,request.CategoryName);

        }

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