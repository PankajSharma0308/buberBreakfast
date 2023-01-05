using buberBreakfast.Contracts.Breakfast;
using buberBreakfast.Models;
using Microsoft.AspNetCore.Mvc;
using buberBreakfast.Services.Breakfasts;
namespace buberBreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class breakfastController : ControllerBase
{

    private readonly IBreakfastServices _breakfastservices;

    public breakfastController(IBreakfastServices breakfastServices)
    {
        _breakfastservices = breakfastServices;
    }

    [HttpPost]
    public IActionResult createBreakfast(createBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.name,
            request.description,
            request.startDateTime,
            request.endDateTime,
            DateTime.UtcNow,
            request.savory,
            request.sweet
        );


        _breakfastservices.createBreakfast(breakfast);


        var response = new breakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet

        );

        return CreatedAtAction(
            nameof(getBreakfast),
            new { Id = breakfast.Id },
            response
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult getBreakfast(Guid id)
    {
        Breakfast breakfast = _breakfastservices.getBreakfast(id);

        var response = new breakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );

        return Ok(response);
    }

    [HttpPut("/{id:guid}")]
    public IActionResult upsertBreakfast(Guid id, upsertBreakfastRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/{id:guid}")]
    public IActionResult deleteBreakfast(Guid id)
    {
        return Ok(id);
    }

}

