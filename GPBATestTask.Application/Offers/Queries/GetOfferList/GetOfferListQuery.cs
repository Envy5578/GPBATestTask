using MediatR;

namespace GPBATestTask.Application.Offers.Queries.GetOfferList;

public class GetOfferListQuery : IRequest<OfferListVm>
{
    public string Stamp { get; set; }
    public string Model { get; set; }
    public string ProviderName { get; set; }
}