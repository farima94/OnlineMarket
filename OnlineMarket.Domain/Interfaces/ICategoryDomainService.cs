using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Domain.Interfaces;

public interface ICategoryDomainService
{
    Task<Category> CreateCategoryAsync(string imageUrl, string name, string description);
}