using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectoryApp
{
    public class PhoneDirectory
    {
        private List<PhoneEntry> entries = new List<PhoneEntry>();

        public void InitializeDefaultEntries()
        {
            entries.Add(new PhoneEntry("John Doe", "123456789"));
            entries.Add(new PhoneEntry("Jane Doe", "987654321"));
            entries.Add(new PhoneEntry("Alice Smith", "456789123"));
            entries.Add(new PhoneEntry("Bob Johnson", "789123456"));
            entries.Add(new PhoneEntry("Charlie Brown", "321654987"));
        }

        public void AddEntry()
        {
            Console.Write("Please enter the name: ");
            string name = Console.ReadLine();
            Console.Write("Please enter the phone number: ");
            string phoneNumber = Console.ReadLine();

            entries.Add(new PhoneEntry(name, phoneNumber));
            Console.WriteLine("The new entry has been added successfully.");
            Console.ReadLine();
        }
        public void DeleteEntry()
        {
            Console.Write("Please enter the name of the person whose number you want to delete: ");
            string name = Console.ReadLine();
            var entry = entries.FirstOrDefault(e => e.GetName() == name);

            if (entry == null)
            {
                Console.WriteLine("No entry found matching your criteria. Please make a selection:");
                Console.WriteLine("* To end deletion: (1)");
                Console.WriteLine("* To try again: (2)");

                if (Console.ReadLine() == "2")
                {
                    DeleteEntry();
                }
            }
            else
            {
                Console.WriteLine($"{entry.GetName()} is about to be deleted from the directory, do you confirm? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    entries.Remove(entry);
                    Console.WriteLine("The entry has been deleted successfully.");
                }
                else
                {
                    Console.WriteLine("The entry has not been deleted.");
                }
                Console.ReadLine();
            }
        }

        public void UpdateEntry()
        {
            Console.Write("Please enter the name of the person whose number you want to update: ");
            string name = Console.ReadLine();
            var entry = entries.FirstOrDefault(e => e.GetName() == name);

            if (entry == null)
            {
                Console.WriteLine("No entry found matching your criteria. Please make a selection:");
                Console.WriteLine("* To end updating: (1)");
                Console.WriteLine("* To try again: (2)");

                if (Console.ReadLine() == "2")
                {
                    UpdateEntry();
                }
            }
            else
            {
                Console.Write("Please enter the new phone number: ");
                string phoneNumber = Console.ReadLine();
                entry.SetPhoneNumber(phoneNumber);
                Console.WriteLine("The entry has been updated successfully.");
                Console.ReadLine();
            }
        }

        public void ListEntries()
        {
            Console.WriteLine("How would you like to sort the directory?");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) A-Z");
            Console.WriteLine("(2) Z-A");

            bool ascending = Console.ReadLine() == "1";
            var sortedEntries = ascending ? entries.OrderBy(e => e.GetName()).ToList() : entries.OrderByDescending(e => e.GetName()).ToList();

            Console.WriteLine("Phone Directory");
            Console.WriteLine("**********************************************");
            foreach (var entry in sortedEntries)
            {
                Console.WriteLine($"Name: {entry.GetName()} Phone Number: {entry.GetPhoneNumber()}");
            }
            Console.ReadLine();
        }
        public void SearchEntries()
        {
            Console.WriteLine("Please select the type of search you want to perform:");
            Console.WriteLine("**********************************************");
            Console.WriteLine("(1) Search by name");
            Console.WriteLine("(2) Search by phone number");

            var searchType = Console.ReadLine();
            if (searchType == "1")
            {
                Console.Write("Please enter the name: ");
                string name = Console.ReadLine();
                var results = entries.Where(e => e.GetName().Contains(name)).ToList();
                DisplaySearchResults(results);
            }
            else if (searchType == "2")
            {
                Console.Write("Please enter the phone number: ");
                string phoneNumber = Console.ReadLine();
                var results = entries.Where(e => e.GetPhoneNumber().Contains(phoneNumber)).ToList();
                DisplaySearchResults(results);
            }
        }
        private void DisplaySearchResults(List<PhoneEntry> results)
        {
            Console.WriteLine("Your search results:");
            Console.WriteLine("**********************************************");
            foreach (var entry in results)
            {
                Console.WriteLine($"Name: {entry.GetName()} Phone Number: {entry.GetPhoneNumber()}");
            }
            Console.ReadLine();
        }
    }
}