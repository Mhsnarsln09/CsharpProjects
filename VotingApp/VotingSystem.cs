using System;
using System.Collections.Generic;
using System.Linq;

public class VotingSystem
{
    private List<Category> categories;
    private List<User> users;

    public VotingSystem()
    {
        categories = new List<Category>
        {
            new Category("Movie Categories"),
            new Category("Tech Stack Categories"),
            new Category("Sports Categories")
        };
        users = new List<User>();
    }

    public List<Category> Categories => categories;

    public void RegisterUser(string username)
    {
        if (!users.Any(u => u.Username == username))
        {
            users.Add(new User(username));
            Console.WriteLine($"{username} has been registered.");
        }
        else
        {
            Console.WriteLine($"{username} is already registered.");
        }
    }

    public bool IsUserRegistered(string username)
    {
        return users.Any(u => u.Username == username);
    }

    public void Vote(string username, int categoryIndex)
    {
        if (categoryIndex >= 0 && categoryIndex < categories.Count)
        {
            categories[categoryIndex].Votes++;
            Console.WriteLine($"{username} voted for {categories[categoryIndex].Name} category.");
        }
        else
        {
            Console.WriteLine("Invalid category selection.");
        }
    }

    public void DisplayResults()
    {
        int totalVotes = categories.Sum(c => c.Votes);
        Console.WriteLine("Voting Results:");
        foreach (var category in categories)
        {
            double percentage = totalVotes > 0 ? (double)category.Votes / totalVotes * 100 : 0;
            Console.WriteLine($"{category.Name}: {category.Votes} votes ({percentage:F2}%)");
        }
    }
}
