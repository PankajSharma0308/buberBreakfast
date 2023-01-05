namespace buberBreakfast.Contracts.Breakfast;

public record createBreakfastRequest(
    string name,
    string description,
    DateTime startDateTime,
    DateTime endDateTime,
    List<string> savory,
    List<string> sweet
);
