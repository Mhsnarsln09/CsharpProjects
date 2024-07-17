using System;
using System.IO;
using ATMApplication.Services;

namespace ATMApplication.Services
{
    public class ReportService
    {
        private readonly TransactionService transactionService;
        private readonly FraudService fraudService;

        public ReportService(TransactionService transactionService, FraudService fraudService)
        {
            this.transactionService = transactionService;
            this.fraudService = fraudService;
        }

        public void GenerateEndOfDayReport()
        {
            string date = DateTime.Now.ToString("ddMMyyyy");
            string reportFile = $"Data/EOD_{date}.txt";

            using (StreamWriter writer = new StreamWriter(reportFile))
            {
                writer.WriteLine("Transactions:");
                foreach (string transaction in transactionService.GetTransactions())
                {
                    writer.WriteLine(transaction);
                }

                writer.WriteLine("\nFraud Attempts:");
                foreach (string fraudAttempt in fraudService.GetFraudAttempts())
                {
                    writer.WriteLine(fraudAttempt);
                }
            }

            Console.WriteLine($"End of Day report generated: {reportFile}");
        }
    }
}
