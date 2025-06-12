using Application.Queries.Auction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class LotController: ControllerBase
{
    private readonly IMediator _mediator;
    
    public LotController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    [HttpGet("{lotNumber}")]
    public async Task<IActionResult> GetLots(int lotNumber)
    {
        Console.WriteLine(lotNumber);
        using StreamReader reader = new StreamReader("__MockResponse__/lot-mock-response.json");
        var json = await reader.ReadToEndAsync();
        
        // dynamic result = JsonConvert.DeserializeObject(json);
        
        return Content(json, "application/json");
    }
    
    [HttpGet("getByAuction/{auctionName}")]
    public async Task<IActionResult> GetLotsByAuction(string auctionName)
    {
        var result = await _mediator.Send(new GetAuctionLotsQuery(auctionName));
        
        // dynamic result = JsonConvert.DeserializeObject(json);
        
        return Ok(result);
    }
}