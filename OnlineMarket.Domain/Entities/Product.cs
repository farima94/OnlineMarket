using System.ComponentModel.DataAnnotations.Schema;
using OnlineMarket.Domain.Exceptions.CustomExceptions;

namespace OnlineMarket.Domain.Entities;


[Table("Product")]
public class Product : EntityBase
{
    public int CategoryId { get; private set; }
    
    public string ImageUrl { get; private set; }
    public string Name { get; private set; }

    public int MainPrice { get; private set; }

    public int DiscountPercent { get; private set; }

    public int DiscountPrice { get; private set; }
    
    
    
    internal Product(int categoryId, string imageUrl, string name, int mainPrice, int discountPercent, int discountPrice)
    {
        this.CategoryId = categoryId;
        this.Name =ValidateName(name);
        this.MainPrice = ValidateMainPrice(mainPrice);
        this.DiscountPercent = discountPercent;
        this.DiscountPrice = discountPrice;
        this.ImageUrl = ValidateImageUrl(imageUrl);

    }

    #region Setter

    internal void SetCategoryId(int categoryId)
    {
        this.CategoryId = categoryId;
    }


    internal void SetProductName(string name)
    {
        this.Name =ValidateName(name);
    }

    internal void SetMainPrice(int mainPrice)
    {
        this.MainPrice =ValidateMainPrice(mainPrice);
    }

    internal void SetDiscountPercent(int discountPercent)
    {
        this.DiscountPercent = discountPercent;
    }


    internal void SetDiscountPrice(int discountPrice)
    {
        this.DiscountPrice = discountPrice;
    }
    
    internal void SetImageUrl(string imageUrl)
    {
        this.ImageUrl = ValidateImageUrl(imageUrl);
    }
    
    #endregion



    #region Validators

    private string ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new MandatoryPropertyException("category's name");
        }

        if (name.Length>25)
        {
            throw new MaxLengthException("category name", 25);
        }

        return name;

    }
    
    
    private string ValidateImageUrl(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            throw new MandatoryPropertyException("image");
        }

        return imageUrl;
    }

    private int ValidateMainPrice(int mainPrice)
    {
        if (mainPrice==null)
        {
            throw new MandatoryPropertyException("mainPrice");
        }

        if (mainPrice.ToString().Length>25)
        {
            throw new MaxLengthException("mainPrice", 25);
        }

        var typeOfMainPrice = mainPrice.GetType();
        if (typeOfMainPrice!=typeof(int))
        {
            throw new FormatException("format of mainPrice is invalid");
        }

        return mainPrice;
    }
   

    #endregion

    #region Relationships

    public Category category { get; set; }

    #endregion
}