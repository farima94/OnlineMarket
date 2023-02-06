using System.ComponentModel.DataAnnotations.Schema;
using OnlineMarket.Domain.Exceptions.CustomExceptions;

namespace OnlineMarket.Domain.Entities;

[Table("Category")]
public class Category : EntityBase
{
    
    public string ImageUrl { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }



    internal Category(string imageUrl, string name, string description)
    {
        this.ImageUrl = ValidateImageUrl(imageUrl);
        this.Name = ValidateName(name);
        this.Description = ValidateDescription(description);
    }


    #region Setter

    internal void SetImageUrl(string imageUrl)
    {
        this.ImageUrl = ValidateImageUrl(imageUrl);
    }

    internal void SetName(string name)
    {
        this.Name = ValidateName(name);
    }

    internal void SetDescription(string description)
    {
        this.Description = description;
    }

    #endregion

    #region Validators

    private string ValidateImageUrl(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            throw new MandatoryPropertyException("image");
        }

        return imageUrl;
    }

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

    private string ValidateDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            throw new MandatoryPropertyException("description");
        }

        return description;
    }

    #endregion

    
    
    #region relationships

    public List<Product> products { get; set; }

    #endregion
   

}