using AutoMapper;
using GPBATestTask.Application.Common.Mappings;
using GPBATestTask.Domain.Entities;

namespace GPBATestTask.Application.Providers.Queries.GetTopProviderList;

public class TopProviderLookupDto : IMapWith<Provider>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Provider, TopProviderLookupDto>()
            .ForMember(providerDto => providerDto.Id,
                opt => opt.MapFrom(provider => provider.Id))
            .ForMember(providerDto => providerDto.Name,
                opt => opt.MapFrom(provider => provider.Name))
            .ForMember(providerDto => providerDto.CreationDate,
                opt => opt.MapFrom(provider => provider.CreationDate));
    }
}