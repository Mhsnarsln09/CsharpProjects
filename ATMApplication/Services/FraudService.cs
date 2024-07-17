using System;
using System.Collections.Generic;

namespace ATMApplication.Services
{
    public class FraudService
    {
        private readonly List<string> fraudAttempts;

        public FraudService()
        {
            fraudAttempts = new List<string>();
        }

        public void LogFraudAttempt(string userId)
        {
            fraudAttempts.Add($"Invalid login attempt by: {userId} at {DateTime.Now}");
        }

        public List<string> GetFraudAttempts()
        {
            return fraudAttempts;
        }
    }
}
