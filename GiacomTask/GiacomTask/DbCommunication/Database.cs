using GiacomTask.DbCommunication.Models;
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

        public List<CallDetail> GetCallsFromTimePeriod(string dateFrom, string dateTo) =>
            context.CallDetails.Where(x => x.CallDate >= DateOnly.Parse(dateFrom) && x.CallDate <= DateOnly.Parse(dateTo)).ToList();

        public string AddNewCallDetailRecord(AddCallDetailsModel addCallDetailsModel)
        {
            var quantityBeforeAdding = context.CallDetails.Count();
            context.CallDetails.Add(new CallDetail()
            {
                CallerID = addCallDetailsModel.CallerID,
                Recipient = addCallDetailsModel.Recipient,
                CallDate = addCallDetailsModel.CallDate,
                EndTime = addCallDetailsModel.EndTime,
                Duration = addCallDetailsModel.Duration,
                Cost = addCallDetailsModel.Cost,
                Reference = addCallDetailsModel.Reference,
                Currency = addCallDetailsModel.Currency
            });

            context.SaveChanges();

            var quantityAfterAdding = context.CallDetails.Count();

            if (quantityBeforeAdding < quantityAfterAdding) return "New call detail record has been added.";
            else return "Something went wrong. Call detail has not been added.";
        }
    }
}
