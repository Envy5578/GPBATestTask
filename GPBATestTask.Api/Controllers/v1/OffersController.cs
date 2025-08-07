using Asp.Versioning;
using AutoMapper;
using GPBATestTask.Api.Models.OfferModels;
using GPBATestTask.Application.Offers.Commands.CreateOffer;
using GPBATestTask.Application.Offers.Queries.GetOfferList;
using Microsoft.AspNetCore.Mvc;

namespace GPBATestTask.Api.Controllers.v1;

[ApiVersion(1, Deprecated = false)]
[Produces("application/json")]
[Route("api/v{version::apiVersion}/[controller]")]
public class OffersController : BaseController
{
    private readonly IMapper _mapper;
    
    public OffersController(IMapper mapper) =>
        _mapper = mapper;
    
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<OfferListVm>> GetAll([FromQuery] GetOfferListRequest offerListRequest)
    {
        var query = _mapper.Map<GetOfferListQuery>(offerListRequest);
        
        var vm = await Mediator.Send(query);
    
        return Ok(vm);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<int>> Create([FromBody] CreateOfferRequest createOfferRequest)
    {
        var command = _mapper.Map<CreateOfferCommand>(createOfferRequest);
        
        var offerId = await Mediator.Send(command);
        
        return CreatedAtAction(nameof(Create), offerId);
    }
}