using NotificationAPI.Services.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace NotificationAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class JobController : ControllerBase
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IPrintService _printService; 

        public JobController(IServiceProvider serviceProvider)
        {
            _recurringJobManager = serviceProvider.GetRequiredService<IRecurringJobManager>();
            _printService = serviceProvider.GetRequiredService<IPrintService>();
        }

        [HttpPost("[Action]")]
        public IActionResult GenerateDocument()
        {
            _recurringJobManager.AddOrUpdate("post-mail", () => _printService.PrintAndSaveDocumentAsync(), "0/1 * * * *");
            return Ok(); 
        }
    }
}
