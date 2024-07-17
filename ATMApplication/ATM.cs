using System;
using System.Collections.Generic;
using ATMApplication.Services; // Add the missing using directive

namespace ATMApplication
{
    public class ATM
    {
        private readonly UserService userService;
        private readonly TransactionService transactionService;
        private readonly FraudService fraudService;
        private readonly ReportService reportService;

        public ATM()
        {
            userService = new UserService();
            transactionService = new TransactionService();
            fraudService = new FraudService();
            reportService = new ReportService(transactionService, fraudService);
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the ATM!");
            while (true)
            {
                Console.WriteLine("Please enter your user ID to login:");
                string userId = Console.ReadLine();
                if (userService.IsValidUser(userId))
                {
                    Console.WriteLine("Login successful!");
                    ShowMenu(userId);
                }
                else
                {
                    Console.WriteLine("Invalid user ID!");
                    fraudService.LogFraudAttempt(userId);
                }
            }
        }

        private void ShowMenu(string userId)
        {
            while (true)
            {
                Console.WriteLine("Select an operation:");
                Console.WriteLine("1. Withdraw Money");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Make a Payment");
                Console.WriteLine("4. End of Day Report");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        transactionService.WithdrawMoney(userId);
                        break;
                    case "2":
                        transactionService.DepositMoney(userId);
                        break;
                    case "3":
                        transactionService.MakePayment(userId);
                        break;
                    case "4":
                        reportService.GenerateEndOfDayReport();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}
