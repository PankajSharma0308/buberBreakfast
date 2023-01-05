using buberBreakfast.Models;

namespace buberBreakfast.Services.Breakfasts;

public interface IBreakfastServices
{
    void createBreakfast(Breakfast request);
    Breakfast getBreakfast(Guid id);
}