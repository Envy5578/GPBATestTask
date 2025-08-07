using AutoMapper;
using AutoMapper.QueryableExtensions;
using GPBATestTask.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GPBATestTask.Application.Providers.Queries.GetTopProviderList;

public class GetTopProviderListQueryHandler : IRequestHandler<GetTopProviderListQuery, TopProviderListVm>
{
    private readonly IGPBATestTaskDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public GetTopProviderListQueryHandler(IGPBATestTaskDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<TopProviderListVm> Handle(GetTopProviderListQuery request, CancellationToken cancellationToken)
    {
        var topProviders = await _dbContext.Providers
            .Include(provider => provider.Offers)
            .OrderByDescending(provider => provider.Offers.Count)
            .Take(3)
            .ProjectTo<TopProviderLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new TopProviderListVm { Providers = topProviders };
    }
}