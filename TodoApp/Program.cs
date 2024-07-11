using TodoApp.Models;

namespace TodoApp;

class Program
{
    static void Main(string[] args)
    {
        var teamMembers = new Dictionary<int, string>{
            {1, "John"},
            {2, "Jane"},
            {3, "Doe"}
        };
        var board = new Board();
        board.InitializeDefaultBoard(teamMembers);

        while (true)
        {
            Console.WriteLine("Please select the action you want to perform :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) List Board");
            Console.WriteLine("(2) Add Card to Board");
            Console.WriteLine("(3) Remove Card from Board");
            Console.WriteLine("(4) Move Card");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    board.ListBoard(teamMembers);
                    break;
                case "2":
                    board.AddCard(teamMembers);
                    break;
                case "3":
                    board.RemoveCard();
                    break;
                case "4":
                    board.MoveCard();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
