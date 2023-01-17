namespace OnlineMarket.Domain.Entities;

public class EntityBase
{
    public int Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
}