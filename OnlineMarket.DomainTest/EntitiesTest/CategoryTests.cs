using OnlineMarket.Domain.Entities;
using OnlineMarket.Domain.Exceptions.CustomExceptions;

namespace OnlineMarket.DomainTest.EntitiesTest;

public class CategoryTests 
{
    
    [Theory]
    [InlineData(" ","name","desc")]
    [InlineData(null,"name","desc")]
    [InlineData("","name","desc")]
    public void SetImageUrl_ShouldReturnMandatoryPropertyException_WhenTheImageUrlIsNullOrEmpty(string imageUrl,string name,string description)
    {
        //Arrange
        var category = new Category("imageUrl",name,description);
        
        //Act
        var action = () =>
        {
            category.SetImageUrl(imageUrl);
           
        };
        //Assert
        Assert.Throws<MandatoryPropertyException>(action);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void SetName_ShouldReturnMandatoryPropertyException_WhenTheNameIsNullOrEmpty( string name)
    {
        //Arrange
        var category = new Category("imageUrl", "name", "description");
        //Act
        var action = () =>
        {
          category.SetName(name);
        };
        //Assert
        Assert.Throws<MandatoryPropertyException>(action);
    }

    
    public static IEnumerable<object[]> Data()
    {
        yield return new object[]
        {
            "imageUrl",
            new string(Enumerable.Repeat('a', 52).ToArray()),
            "description",

        };
        yield return new object[]
        {
            "imageUrl",
            new string(Enumerable.Repeat('a', 26).ToArray()),
            "description",
        };
    }
    
    
    [Theory]
    [MemberData(nameof(Data))]
    public void SetName_ShouldReturnMaxLengthException_WhenTheLengthOfNameIsGreaterThan25(string imageUrl, string name,
        string description)
    {
        //Arrange
        var category = new Category(imageUrl, "name", description);
        //Act
        var action = () =>
        {
           category.SetName(name);
        };
        //Assert
        Assert.Throws<MaxLengthException>(action);
    }

 
}