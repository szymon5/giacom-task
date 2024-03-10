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
    }
}
