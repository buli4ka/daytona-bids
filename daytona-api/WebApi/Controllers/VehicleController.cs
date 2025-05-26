using Application.Cars.Commands.CreateVehicle;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehicleController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }


    [HttpPost]
    public async Task<IActionResult> CreateVehicle()
    {
        var vehicle = await _mediator.Send(new CreateVehicleCommand());
        return Ok(vehicle);
    }
    
    
}