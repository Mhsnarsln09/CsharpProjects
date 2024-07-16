using System;

class Program
{
    static void Main(string[] args)
    {
        VotingSystem votingSystem = new VotingSystem();
        bool continueVoting = true;

        while (continueVoting)
        {
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();

            if (!votingSystem.IsUserRegistered(username))
            {
                Console.WriteLine("User not found. Would you like to register? (Y/N)");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    votingSystem.RegisterUser(username);
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine("Categories:");
            for (int i = 0; i < votingSystem.Categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {votingSystem.Categories[i].Name}");
            }

            Console.WriteLine("Please enter the number of the category you want to vote for:");
            if (int.TryParse(Console.ReadLine(), out int categoryIndex))
            {
                votingSystem.Vote(username, categoryIndex - 1);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }

            Console.WriteLine("Would you like to vote again? (Y/N)");
            if (Console.ReadLine().ToUpper() != "Y")
            {
                continueVoting = false;
            }
        }

        votingSystem.DisplayResults();
    }
}
