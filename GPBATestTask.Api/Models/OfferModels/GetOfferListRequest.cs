using AutoMapper;
using GPBATestTask.Application.Common.Mappings;
using GPBATestTask.Application.Offers.Queries.GetOfferList;

namespace GPBATestTask.Api.Models.OfferModels;

public class GetOfferListRequest : IMapWith<GetOfferListQuery>
{
    public string Stamp { get; set; }
    public string Model { get; set; }
    public string ProviderName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GetOfferListRequest, GetOfferListQuery>()
            .ForMember(offerListQuery => offerListQuery.Stamp,
                opt => opt.MapFrom(offerListRequest => offerListRequest.Stamp))
            .ForMember(offerListQuery => offerListQuery.Model,
                opt => opt.MapFrom(offerListRequest => offerListRequest.Model))
            .ForMember(offerListQuery => offerListQuery.ProviderName,
                opt => opt.MapFrom(offerListRequest => offerListRequest.ProviderName));
    }
}