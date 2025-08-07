namespace GPBATestTask.Application.Offers.Queries.GetOfferList;

public class OfferListVm
{
    public IList<OfferLookupDto> Offers { get; set; }
    public int Total { get; set; }
}