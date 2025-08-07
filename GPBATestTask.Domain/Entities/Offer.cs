namespace GPBATestTask.Domain.Entities;

public class Offer
{
    public int Id { get; set; }
    public string Stamp { get; set; }
    public string Model { get; set; }
    public int ProviderId { get; set; }
    public Provider Provider { get; set; }
    public DateTime RegistrationDate { get; set; }
}