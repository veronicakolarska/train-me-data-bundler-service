using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using TrainMe.DataBundler.Services.Common;

namespace TrainMe.DataBundler.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ExportController : ControllerBase
{
    private readonly ILogger<ExportController> logger;
    private readonly IEventBusService eventBusService;

    public ExportController(
        ILogger<ExportController> logger,
        IEventBusService eventBusService
    )
    {
        this.logger = logger;
        this.eventBusService = eventBusService;
    }

    [HttpGet(Name = "User")]
    public ActionResult ExportUser(int id)
    {
        this.logger.LogInformation("starting test publish", id);

        this.eventBusService.SendMessage("HelloWorld", "test-queue");

        this.logger.LogInformation("exporting user data for user", id);
        return this.Ok();
    }
}
