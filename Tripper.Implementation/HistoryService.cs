using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripper.Models.TripSearch;

namespace Tripper.Implementation
{
    public static class HistoryService
    {
        private static readonly Dictionary<string, List<CreateSessionViewModel>> allHistory = new Dictionary<string, List<CreateSessionViewModel>>();

        public static void AddHistoryRecord(CreateSessionViewModel viewModel, string userId)
        {
            List<CreateSessionViewModel> userHistory;

            if (!allHistory.TryGetValue(userId, out userHistory))
            {
                userHistory = new List<CreateSessionViewModel>();
                allHistory.Add(userId, userHistory);
            }

            userHistory.Add(viewModel);
        }

        public static List<CreateSessionViewModel> GetHistoryRecords(string userId)
        {
            List<CreateSessionViewModel> userHistory = new List<CreateSessionViewModel>();

            if (!allHistory.TryGetValue(userId, out userHistory))
            {
                userHistory = new List<CreateSessionViewModel>();
            }

            return userHistory;
        }

        public static void RemoveHistory(string userId)
        {
            List<CreateSessionViewModel> userHistory;

            if (allHistory.TryGetValue(userId, out userHistory))
            {
                allHistory[userId] = new List<CreateSessionViewModel>();
            }
        }
    }
}
