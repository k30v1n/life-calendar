namespace life_calendar.Controllers.LifeCalendar;

public class LifeCalendarResponse
{
    public YearOfLifeResponse[] YearsOfLife { get; set; } = new YearOfLifeResponse[90];

}

public class YearOfLifeResponse
{
    public int Age { get; set; }
    public int Year { get; set; }
    public WeekResponse[] Weeks { get; set; } = new WeekResponse[52];
}

public class WeekResponse
{
    public bool Lived { get; set; }
    public DateTime Date { get; set; }
}