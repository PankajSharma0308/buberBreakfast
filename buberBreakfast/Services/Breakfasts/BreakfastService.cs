using System.Runtime.CompilerServices;
namespace buberBreakfast.Services.Breakfasts;
using buberBreakfast.Models;
public class BreakfastServices : IBreakfastServices
{
    private static Dictionary<Guid, Breakfast> _breakfasts = new();

    public void createBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public Breakfast getBreakfast(Guid id)
    {
        return _breakfasts[id];
    }

    public void upsertBreakfast(Breakfast breakfast)
    {
        _breakfasts[breakfast.Id] = breakfast;
    }
}