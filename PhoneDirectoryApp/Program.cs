namespace PhoneDirectoryApp;

class Program
{
    static void Main(string[] args)
    {
        PhoneDirectory phoneDirectory = new PhoneDirectory();
        phoneDirectory.InitializeDefaultEntries();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please select the operation you want to perform :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Save a new number");
            Console.WriteLine("(2) Delete an existing number");
            Console.WriteLine("(3) Update an existing number");
            Console.WriteLine("(4) List the directory");
            Console.WriteLine("(5) Search the directory");
            Console.WriteLine("(0) Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    phoneDirectory.AddEntry();
                    break;
                case "2":
                    phoneDirectory.DeleteEntry();
                    break;
                case "3":
                    phoneDirectory.UpdateEntry();
                    break;
                case "4":
                    phoneDirectory.ListEntries();
                    break;
                case "5":
                    phoneDirectory.SearchEntries();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid selection! Please try again.");
                    break;
            }
        }
    }
}
