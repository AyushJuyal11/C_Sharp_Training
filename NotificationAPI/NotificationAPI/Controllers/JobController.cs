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

        public JobController(IRecurringJobManager recurringJobManager, IServiceProvider serviceProvider)
        {
            _recurringJobManager = recurringJobManager;
            _printService = serviceProvider.GetRequiredService<IPrintService>();
        }

        [HttpPost("[Action]")]
        public IActionResult SendMail()
        {
            _recurringJobManager.AddOrUpdate("post-mail", () => _printService.InitiateRequestAsync(), "0/1 * * * *");
            return Ok(); 
        }
    }
}
