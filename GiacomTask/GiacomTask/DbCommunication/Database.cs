using GiacomTask.Interfaces;
using GiacomTask.Models;
using GiacomTask.Services;

namespace GiacomTask.DbCommunication
{
    public class Database : IDatabase
    {
        private readonly ApplicationDbContext context;

        public Database(ApplicationDbContext context) => this.context = context;

        public List<CallDetail> GetAllCalls() => context.CallDetails.ToList();

        public long GetAverageCallDuration() => (long)context.CallDetails.ToList().Average(x => x.Duration);

        public long GetMaxCallDuration() => context.CallDetails.ToList().Max(x => x.Duration);

        public long GetMinCallDuration() => context.CallDetails.ToList().Min(x => x.Duration);
    }
}
