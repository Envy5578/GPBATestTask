using AutoMapper;
using AutoMapper.QueryableExtensions;
using GPBATestTask.Application.Common.Extensions;
using GPBATestTask.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GPBATestTask.Application.Offers.Queries.GetOfferList;

public class GetOfferListQueryHandler : IRequestHandler<GetOfferListQuery, OfferListVm>
{
    private readonly IGPBATestTaskDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetOfferListQueryHandler(IGPBATestTaskDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<OfferListVm> Handle(GetOfferListQuery request, CancellationToken cancellationToken)
    {
        var offers = await _dbContext.Offers
            .Include(offer => offer.Provider)
            .WhereIf(!string.IsNullOrEmpty(request.Stamp),
                offer => offer.Stamp.Equals(request.Stamp))
            .WhereIf(!string.IsNullOrEmpty(request.Model),
                offer => offer.Model.Equals(request.Model))
            .WhereIf(!string.IsNullOrEmpty(request.ProviderName),
                offer => offer.Provider.Name.Equals(request.ProviderName))
            .ProjectTo<OfferLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new OfferListVm
        {
            Offers = offers,
            Total = offers.Count
        };
    }
}