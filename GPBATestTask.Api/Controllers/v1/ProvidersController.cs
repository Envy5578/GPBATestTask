using Asp.Versioning;
using AutoMapper;
using GPBATestTask.Application.Providers.Queries.GetTopProviderList;
using Microsoft.AspNetCore.Mvc;

namespace GPBATestTask.Api.Controllers.v1;

[ApiVersion(1, Deprecated = false)]
[Produces("application/json")]
[Route("api/v{version::apiVersion}/[controller]")]
public class ProvidersController : BaseController
{
    private readonly IMapper _mapper;
    
    public ProvidersController(IMapper mapper) =>
        _mapper = mapper;

    [HttpGet("TopProviders")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<TopProviderListVm>> GetTopProviders()
    {
        var query = new GetTopProviderListQuery { };
        
        var vm = await Mediator.Send(query);
        
        return Ok(vm);
    }
}