using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class Board
    {
        private Dictionary<string, List<Card>> _board;

        public Board()
        {
            _board = new Dictionary<string, List<Card>>
            {
                { "TODO", new List<Card>() },
                { "IN PROGRESS", new List<Card>() },
                { "DONE", new List<Card>() }
            };
        }

        public void InitializeDefaultBoard(Dictionary<int, string> teamMembers)
        {
            _board["TODO"].Add(new Card { Title = "Sample Task 1", Content = "Content 1", AssignedPersonId = 1, Size = Size.M });
            _board["IN PROGRESS"].Add(new Card { Title = "Sample Task 2", Content = "Content 2", AssignedPersonId = 2, Size = Size.L });
            _board["DONE"].Add(new Card { Title = "Sample Task 3", Content = "Content 3", AssignedPersonId = 3, Size = Size.S });
        }

        public void ListBoard(Dictionary<int, string> teamMembers)
        {
            Console.WriteLine("TODO Line");
            Console.WriteLine("************************");
            ListCards(_board["TODO"], teamMembers);

            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("************************");
            ListCards(_board["IN PROGRESS"], teamMembers);

            Console.WriteLine("DONE Line");
            Console.WriteLine("************************");
            ListCards(_board["DONE"], teamMembers);
        }

        private void ListCards(List<Card> cards, Dictionary<int, string> teamMembers)
        {
            if (cards.Count == 0)
            {
                Console.WriteLine("~ EMPTY ~");
                return;
            }

            foreach (var card in cards)
            {
                Console.WriteLine($"Title      : {card.Title}");
                Console.WriteLine($"Content    : {card.Content}");
                Console.WriteLine($"Assigned To: {teamMembers[card.AssignedPersonId]}");
                Console.WriteLine($"Size       : {card.Size}");
                Console.WriteLine("-");
            }
        }

        public void AddCard(Dictionary<int, string> teamMembers)
        {
            Console.WriteLine("Enter Title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Enter Content: ");
            var content = Console.ReadLine();

            Console.WriteLine("Select Size -> XS(1),S(2),M(3),L(4),XL(5): ");
            var size = (Size)int.Parse(Console.ReadLine());

            Console.WriteLine("Select Person: ");
            foreach (var member in teamMembers)
            {
                Console.WriteLine($"{member.Key} - {member.Value}");
            }
            var assignedPersonId = int.Parse(Console.ReadLine());

            if (!teamMembers.ContainsKey(assignedPersonId))
            {
                Console.WriteLine("Invalid entry. Operation canceled!");
                return;
            }

            var newCard = new Card
            {
                Title = title,
                Content = content,
                Size = size,
                AssignedPersonId = assignedPersonId
            };

            _board["TODO"].Add(newCard);
            Console.WriteLine("Card added successfully!");
        }

        public void RemoveCard()
        {
            Console.WriteLine("First, you need to select the card you want to delete.");
            Console.WriteLine("Please enter the card title: ");
            var title = Console.ReadLine();

            var card = FindCardByTitle(title);

            if (card == null)
            {
                Console.WriteLine("No card matching your criteria was found on the board. Please make a selection.");
                Console.WriteLine("* To end deletion: (1)");
                Console.WriteLine("* To try again: (2)");

                var choice = Console.ReadLine();
                if (choice == "2")
                {
                    RemoveCard();
                }
                return;
            }

            foreach (var line in _board.Keys)
            {
                _board[line].RemoveAll(c => c.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            }

            Console.WriteLine("Card deleted successfully!");
        }

        public void MoveCard()
        {
            Console.WriteLine("First, you need to select the card you want to move.");
            Console.WriteLine("Please enter the card title: ");
            var title = Console.ReadLine();

            var card = FindCardByTitle(title);

            if (card == null)
            {
                Console.WriteLine("No card matching your criteria was found on the board. Please make a selection.");
                Console.WriteLine("* To end operation: (1)");
                Console.WriteLine("* To try again: (2)");

                var choice = Console.ReadLine();
                if (choice == "2")
                {
                    MoveCard();
                }
                return;
            }

            Console.WriteLine("Card Information:");
            Console.WriteLine("**************************************");
            Console.WriteLine($"Title       : {card.Title}");
            Console.WriteLine($"Content     : {card.Content}");
            Console.WriteLine($"Assigned To : {card.AssignedPersonId}");
            Console.WriteLine($"Size        : {card.Size}");
            Console.WriteLine($"Current Line: {card.CurrentLine}");

            Console.WriteLine("Please select the line you want to move the card to:");
            Console.WriteLine("(1) TODO");
            Console.WriteLine("(2) IN PROGRESS");
            Console.WriteLine("(3) DONE");

            var lineChoice = Console.ReadLine();
            string newLine = lineChoice switch
            {
                "1" => "TODO",
                "2" => "IN PROGRESS",
                "3" => "DONE",
                _ => null
            };

            if (newLine == null)
            {
                Console.WriteLine("Invalid selection! Operation canceled.");
                return;
            }

            _board[card.CurrentLine].Remove(card);
            card.CurrentLine = newLine;
            _board[newLine].Add(card);

            Console.WriteLine("Card moved successfully!");
        }

        private Card FindCardByTitle(string title)
        {
            foreach (var line in _board.Keys)
            {
                var card = _board[line].FirstOrDefault(c => c.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                if (card != null)
                {
                    card.CurrentLine = line;
                    return card;
                }
            }
            return null;
        }
    }
}