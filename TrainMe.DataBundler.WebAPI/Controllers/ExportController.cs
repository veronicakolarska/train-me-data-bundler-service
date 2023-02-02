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

        using var connection = this.eventBusService.CreateChannel();
        using var model = connection.CreateModel();
        var body = Encoding.UTF8.GetBytes("Hi");
        model.BasicPublish(string.Empty,
                                string.Empty,
                                basicProperties: null,
                                body: body);

        this.logger.LogInformation("exporting user data for user", id);
        return this.Ok();
    }
}
