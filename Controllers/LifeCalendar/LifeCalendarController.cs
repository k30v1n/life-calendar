using Microsoft.AspNetCore.Mvc;

namespace life_calendar.Controllers.LifeCalendar;

[ApiController]
[Route("[controller]")]
public class LifeCalendarController : ControllerBase
{
    private readonly ILogger<LifeCalendarController> _logger;

    public LifeCalendarController(ILogger<LifeCalendarController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public LifeCalendarResponse Get()
    {
        var date = new DateTime(1991, 10, 21);
        var now = DateTime.Now;

        var response = new LifeCalendarResponse();
        
        for(int i = 0; i< response.YearsOfLife.Length; i++)
        {
            var yearOfLife = new YearOfLifeResponse();

            yearOfLife.Age = i;
            yearOfLife.Year = date.Year;

            for(int j = 0; j < yearOfLife.Weeks.Length;j++)
            {
                var week = new WeekResponse();

                date = date.AddDays(7);

                week.Lived = date < now;
                week.Date = date;

                yearOfLife.Weeks[j] = week;
            }

            response.YearsOfLife[i] = yearOfLife;
        }
        return response;
    }
}
