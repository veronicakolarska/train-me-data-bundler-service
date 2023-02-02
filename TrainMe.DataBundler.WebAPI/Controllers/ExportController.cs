using Microsoft.AspNetCore.Mvc;

namespace TrainMe.DataBundler.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ExportController : ControllerBase
{
    private readonly ILogger<ExportController> _logger;

    public ExportController(ILogger<ExportController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "User")]
    public ActionResult ExportUser(int id)
    {
        this._logger.LogInformation("exporting user data for user", id);
        return this.Ok();
    }
}
