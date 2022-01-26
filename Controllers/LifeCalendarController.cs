using Microsoft.AspNetCore.Mvc;
namespace life_calendar.Controllers;

[ApiController]
[Route("[controller]")]
public class LifeCalendarController : ControllerBase
{
    private readonly ILogger<LifeCalendarController> _logger;
    public LifeCalendarController(ILogger<LifeCalendarController> logger) => _logger = logger;

    [HttpGet]
    public LifeCalendarResponse Get(DateTime date)
    {
        var now = DateTime.Now;

        var response = new LifeCalendarResponse(new YearOfLifeResponse[91]);

        for (int i = 0; i < response.YearsOfLife.Length; i++)
        {
            var yearOfLife = new YearOfLifeResponse(Age: i, Year: date.Year, Weeks: new WeekResponse[52]);

            for (int j = 0; j < yearOfLife.Weeks.Length; j++)
            {
                var week = new WeekResponse(Lived: date < now, Date: date);

                yearOfLife.Weeks[j] = week;

                date = date.AddDays(7);
            }

            response.YearsOfLife[i] = yearOfLife;
        }
        return response;
    }
}
