using Microsoft.AspNetCore.Mvc;

namespace buberBreakfast.Controllers;

public class errorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}