namespace GPBATestTask.Domain.Entities;

public class Provider
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public ICollection<Offer> Offers { get; set; }
}