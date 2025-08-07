using AutoMapper;
using GPBATestTask.Application.Common.Mappings;
using GPBATestTask.Domain.Entities;

namespace GPBATestTask.Application.Offers.Queries.GetOfferList;

public class OfferLookupDto : IMapWith<Offer>
{
    public int Id { get; set; }
    public string Stamp { get; set; }
    public string Model { get; set; }
    public int ProviderId { get; set; }
    public DateTime RegistrationDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Offer, OfferLookupDto>()
            .ForMember(offerDto => offerDto.Id,
                opt => opt.MapFrom(offer => offer.Id))
            .ForMember(offerDto => offerDto.Stamp,
                opt => opt.MapFrom(offer => offer.Stamp))
            .ForMember(offerDto => offerDto.Model,
                opt => opt.MapFrom(offer => offer.Model))
            .ForMember(offerDto => offerDto.ProviderId,
                opt => opt.MapFrom(offer => offer.ProviderId))
            .ForMember(offerDto => offerDto.RegistrationDate,
                opt => opt.MapFrom(offer => offer.RegistrationDate));
    }
}