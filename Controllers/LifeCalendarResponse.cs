namespace life_calendar.Controllers;

public record LifeCalendarResponse(YearOfLifeResponse[] YearsOfLife);

public record YearOfLifeResponse(int Age, int Year, WeekResponse[] Weeks);

public record WeekResponse(bool Lived, DateTime Date);