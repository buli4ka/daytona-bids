using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuctionController: ControllerBase
{
    private readonly IMediator _mediator;

    public AuctionController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }


    [HttpGet]
    public async Task<IActionResult> GetAuctions()
    {
        using StreamReader reader = new StreamReader("__MockResponse__/main-vehicle.json");
        var json = await reader.ReadToEndAsync();
        
        // dynamic result = JsonConvert.DeserializeObject(json);
        
        return Content(json, "application/json");
    }
    
}