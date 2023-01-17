using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.DomainServices;
using OnlineMarket.Domain.Entities;
using OnlineMarket.Domain.Exceptions.CustomExceptions;
using OnlineMarket.Domain.Interfaces;
using OnlineMarket.DomainTest.Persistence;

namespace OnlineMarket.DomainTest;

[Collection("Database collection")]
public class CategoryDomainServiceTest : IDisposable
{
    private readonly IApplicationDbContext _context;
    private List<int> _catIds;


    public CategoryDomainServiceTest(DomainDatabaseFixture databaseFixture)
    {
        _context = databaseFixture.Context;
        _catIds = new List<int>();
    }

    [Theory]
    [InlineData("digital", "name", "desc")]
    public async void CreateCategory_ShouldReturnCategory_WhenTheCategoryHasBeenCreated(string imageUrl, string name,
        string description)
    {
        //Arrange

        var categoryDomainService = new CategoryDomainService(_context);

        //Act
        var category = await categoryDomainService.CreateCategoryAsync(imageUrl, name, description);
        var resultImageUrl = category.ImageUrl;
        var resultName = category.Name;
        var resultDescription = category.Description;

        //Assert
        Assert.Equal(resultImageUrl, imageUrl);
        Assert.Equal(resultName, name);
        Assert.Equal(resultDescription, description);
    }


    [Theory]
    [InlineData("digital", "clothes", "desc")]
    public async Task CreateCategory_ShouldThrowDuplicatePropertyException_WhenTheCategoryNameHasBeenExisted(
        string imageUrl, string name, string description)
    {
        //Arrange

        var categoryDomainService = new CategoryDomainService(_context);
        var category = await categoryDomainService.CreateCategoryAsync(imageUrl, name, description);
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        
        _catIds.Add(category.Id);


        //Act
        var action = async () => { await categoryDomainService.CreateCategoryAsync("scfdcf", "clothes", "description"); };
        
        //Assert

        await Assert.ThrowsAsync<DuplicatePropertyException>(action);
    }

    public void Dispose()
    {
        var catsToDelete = _context.Categories.Where(w => _catIds.Any(a => a == w.Id)).ToList();

        _context.Categories.RemoveRange(catsToDelete);
    }
}