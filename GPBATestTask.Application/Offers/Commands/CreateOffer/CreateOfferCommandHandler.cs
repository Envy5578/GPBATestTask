using GPBATestTask.Application.Interfaces;
using GPBATestTask.Domain.Entities;
using MediatR;

namespace GPBATestTask.Application.Offers.Commands.CreateOffer;

public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, int>
{
    private readonly IGPBATestTaskDbContext _dbContext;
    
    public CreateOfferCommandHandler(IGPBATestTaskDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<int> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = new Offer
        {
            Stamp = request.Stamp,
            Model = request.Model,
            ProviderId = request.ProviderId,
            RegistrationDate = request.RegistrationDate
        };
        
        await _dbContext.Offers.AddAsync(offer, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return offer.Id;
    }
}