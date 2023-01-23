using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Domain.Interfaces;

public interface ICategoryDomainService
{
    Task<Category> CreateCategoryAsync(string imageUrl, string name, string description);
    Task UpdateCategoryNameAsync(Category category, string name);
    Task UpdateCategoryDescriptionAsync(Category category, string description);
    Task UpdateCategoryImageUrlAsync(Category category, string imageUrl);
}