using buberBreakfast.Models;
using ErrorOr;

namespace buberBreakfast.Services.Breakfasts;

public interface IBreakfastServices
{
    ErrorOr<Created> createBreakfast(Breakfast request);
    ErrorOr<Breakfast> getBreakfast(Guid id);
    ErrorOr<upsertedBreakfast> upsertBreakfast(Breakfast breakfast);
    ErrorOr<Deleted> deleteBreakfast(Guid id);
}
