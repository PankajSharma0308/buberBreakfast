using System.Runtime.CompilerServices;
namespace buberBreakfast.Services.Breakfasts;
using buberBreakfast.Models;
using buberBreakfast.ServiceErrors;
using ErrorOr;

public class BreakfastServices : IBreakfastServices
{
    private static Dictionary<Guid, Breakfast> _breakfasts = new();

    public ErrorOr<Created> createBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
        return Result.Created;
    }

    public ErrorOr<Breakfast> getBreakfast(Guid id)
    {
        if (_breakfasts.TryGetValue(id, out var breakfast))
        {
            return breakfast;
        }

        return Errors.Breakfast.NotFound;
    }

    public ErrorOr<upsertedBreakfast> upsertBreakfast(Breakfast breakfast)
    {
        var isNewlyCreated = !_breakfasts.ContainsKey(breakfast.Id);
        _breakfasts[breakfast.Id] = breakfast;

        return new upsertedBreakfast(isNewlyCreated);
    }

    public ErrorOr<Deleted> deleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
        return Result.Deleted;
    }
}