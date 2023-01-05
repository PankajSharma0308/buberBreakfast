namespace buberBreakfast.Contracts.Breakfast;

public record breakfastResponse(
    Guid id,
    string name,
    string description,
    DateTime startDateTime,
    DateTime endDateTime,
    DateTime lastModifiedDateTime,
    List<string> savory,
    List<string> sweet
);