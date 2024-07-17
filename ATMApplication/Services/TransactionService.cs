using System;
using System.Collections.Generic;

namespace ATMApplication.Services
{
    public class TransactionService
    {
        private readonly List<string> transactions;

        public TransactionService()
        {
            transactions = new List<string>();
        }

        public void WithdrawMoney(string userId)
        {
            Console.WriteLine("Enter amount to withdraw:");
            string amount = Console.ReadLine();
            transactions.Add($"User {userId} withdrew {amount} at {DateTime.Now}");
            Console.WriteLine("Withdrawal successful!");
        }

        public void DepositMoney(string userId)
        {
            Console.WriteLine("Enter amount to deposit:");
            string amount = Console.ReadLine();
            transactions.Add($"User {userId} deposited {amount} at {DateTime.Now}");
            Console.WriteLine("Deposit successful!");
        }

        public void MakePayment(string userId)
        {
            Console.WriteLine("Enter amount to pay:");
            string amount = Console.ReadLine();
            transactions.Add($"User {userId} made a payment of {amount} at {DateTime.Now}");
            Console.WriteLine("Payment successful!");
        }

        public List<string> GetTransactions()
        {
            return transactions;
        }
    }
}
