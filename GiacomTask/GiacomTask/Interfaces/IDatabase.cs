﻿using GiacomTask.Models;

namespace GiacomTask.Interfaces
{
    public interface IDatabase
    {
        public List<CallDetail> GetAllCalls();
        public long GetAverageCallDuration();
        public long GetMaxCallDuration();
        public long GetMinCallDuration();
    }
}
