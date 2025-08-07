using MediatR;

namespace GPBATestTask.Application.Offers.Commands.CreateOffer;

public class CreateOfferCommand : IRequest<int>
{
    public string Stamp { get; set; }
    public string Model { get; set; }
    public int ProviderId { get; set; }
    public DateTime RegistrationDate { get; set; }
}