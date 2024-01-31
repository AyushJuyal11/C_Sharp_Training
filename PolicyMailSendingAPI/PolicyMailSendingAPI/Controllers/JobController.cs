using PolicyMailSendingAPI.Services.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace PolicyMailSendingAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class JobController : ControllerBase
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IMailSendingService _mailSendingService; 

        public JobController(IRecurringJobManager recurringJobManager, IMailSendingService mailSendingService)
        {
            _recurringJobManager = recurringJobManager;
            _mailSendingService = mailSendingService;
        }

        [HttpPost("[Action]")]
        public IActionResult SendMail()
        {
            _recurringJobManager.AddOrUpdate("Job1", () => _mailSendingService.SendMailAsync(), "0/1 * * * *");
            return Ok(); 
        }
    }
}
