using buberBreakfast.Contracts.Breakfast;
using buberBreakfast.Models;
using Microsoft.AspNetCore.Mvc;
using buberBreakfast.Services.Breakfasts;
using ErrorOr;
using buberBreakfast.ServiceErrors;

namespace buberBreakfast.Controllers;


public class breakfastController : apiController
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


        ErrorOr<Breakfast> createBreakfastResult = _breakfastservices.createBreakfast(breakfast);

        return createBreakfastResult.Match(

        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult getBreakfast(Guid id)
    {
        ErrorOr<Breakfast> getBreakfastResult = _breakfastservices.getBreakfast(id);

        return getBreakfastResult.Match(
            breakfast => Ok(MapBreakfastResponse(breakfast)),
            errors => Problem(errors)
        );
    }

    private static breakfastResponse MapBreakfastResponse(Breakfast breakfast)
    {
        return new breakfastResponse(
                    breakfast.Id,
                    breakfast.Name,
                    breakfast.Description,
                    breakfast.StartDateTime,
                    breakfast.EndDateTime,
                    breakfast.LastModifiedDateTime,
                    breakfast.Savory,
                    breakfast.Sweet
                );
    }

    [HttpPut("/{id:guid}")]
    public IActionResult upsertBreakfast(Guid id, upsertBreakfastRequest request)
    {
        ErrorOr<upsertedBreakfast> upsertBreakfastResult = _breakfastservices.upsertBreakfast(breakfast);

        return upsertBreakfastResult.Match(
            upserted => upserted.isNewlyCreated ? createdAsGetBreakfast(breakfast) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("/{id:guid}")]
    public IActionResult deleteBreakfast(Guid id)
    {
        ErrorOr<Deleted> deletedBreakfastResult = _breakfastService.deleteBreakfast(id);

        return deletedBreakfastResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }


    private IActionResult createdAsGetBreakfast(Breakfast breakfast)
    {
        return CreatedAtAction(
            nameof(getBreakfast),
            new { Id = breakfast.Id },
            MapBreakfastResponse(breakfast)
        );
    }

}

