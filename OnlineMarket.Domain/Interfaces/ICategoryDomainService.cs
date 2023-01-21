using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Domain.Interfaces;

public interface ICategoryDomainService
{
    Task<Category> CreateCategoryAsync(string imageUrl, string name, string description);

    Task UpdateCategoryAsync(Category category, string imageUrl, string name, string description);

    Task UpdateCategoryNameAsync(Category category, string name);
}