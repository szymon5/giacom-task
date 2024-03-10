using GiacomTask.DbCommunication;
using GiacomTask.DbCommunication.Models;
using GiacomTask.Interfaces;
using GiacomTask.Models;
using GiacomTask.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GiacomTask.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CallDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private IDatabase database;

        public CallDetailsController(ApplicationDbContext context)
        {
            this.context = context;
            database = new Database(context);
        }

        [HttpGet("GetAllCalls")]
        public List<CallDetail> GetAllCalls() => database.GetAllCalls();

        [HttpGet("GetAverageCallDuration")]
        public long GetAverageCallDuration() => database.GetAverageCallDuration();
    }
}
