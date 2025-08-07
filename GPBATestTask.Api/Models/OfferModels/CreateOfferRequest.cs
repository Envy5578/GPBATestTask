using AutoMapper;
using GPBATestTask.Application.Common.Mappings;
using GPBATestTask.Application.Offers.Commands.CreateOffer;
using GPBATestTask.Application.Offers.Queries.GetOfferList;

namespace GPBATestTask.Api.Models.OfferModels;

public class CreateOfferRequest : IMapWith<CreateOfferCommand>
{
    public string Stamp { get; set; }
    public string Model { get; set; }
    public int ProviderId { get; set; }
    public DateTime RegistrationDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOfferRequest, CreateOfferCommand>()
            .ForMember(createOfferCommand => createOfferCommand.Stamp,
                opt => opt.MapFrom(createOfferRequest => createOfferRequest.Stamp))
            .ForMember(createOfferCommand => createOfferCommand.Model,
                opt => opt.MapFrom(createOfferRequest => createOfferRequest.Model))
            .ForMember(createOfferCommand => createOfferCommand.ProviderId,
                opt => opt.MapFrom(createOfferRequest => createOfferRequest.ProviderId))
            .ForMember(createOfferCommand => createOfferCommand.RegistrationDate,
                opt => opt.MapFrom(createOfferRequest => createOfferRequest.RegistrationDate));
    }
}