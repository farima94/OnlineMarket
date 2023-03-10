using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Entities;
using OnlineMarket.Domain.Exceptions.CustomExceptions;
using OnlineMarket.Domain.Interfaces;

namespace OnlineMarket.Domain.DomainServices;

public class CategoryDomainService : ICategoryDomainService
{
    private readonly IApplicationDbContext _context;

    public  CategoryDomainService(IApplicationDbContext context)
    {
        _context = context;
    }

   public async Task<Category> CreateCategoryAsync(string imageUrl,string name,string description)
    {
        if (await CategoryExistsAsync(name))
        {
            throw new DuplicatePropertyException("Category name is Exist ");
        }
        return new  Category(imageUrl, name, description);
    }
   

  public async Task UpdateCategoryNameAsync(Category category, string name)
  {
      if (await CategoryExistsAsync(name, category.Id))
      {
          throw new DuplicatePropertyException("Category name is Exist");
      }
      category.SetName(name);
     
  }
  
  public async Task UpdateCategoryDescriptionAsync(Category category, string description)
  {
      category.SetDescription(description);
      
  }

  public async Task UpdateCategoryImageUrlAsync(Category category, string imageUrl)
  {
      category.SetImageUrl(imageUrl);
  }
  
    
    #region validation

    private async Task<bool> CategoryExistsAsync(string name, int? id=null)
    {
        var query = _context.Categories
            .Where(w => w.Name == name).AsQueryable().AsNoTracking();

        return await query.AnyAsync();

    }

    #endregion
               
}