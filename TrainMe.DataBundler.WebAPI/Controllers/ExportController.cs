using Microsoft.AspNetCore.Mvc;

namespace TrainMe.DataBundler.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ExportController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "User")]
    public ActionResult ExportUser()
    {
        this._logger.Info();
        return this.Ok();
    }
}
