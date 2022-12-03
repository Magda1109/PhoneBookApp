using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from the PhoneBook app. What would you like to do? Press 'q' to close.");

            Console.WriteLine("1 Add contact");
            Console.WriteLine("2 Display contact by number");
            Console.WriteLine("3 Display contact by name");
            Console.WriteLine("4 Display all contacts");
            Console.WriteLine("5 Search contacts");
            Console.WriteLine("6 Remove contact");

            var userInput = Console.ReadLine();
            var phoneBook = new PhoneBook();

            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Insert number (required format: XXXXXXXXX)");
                        var number = Console.ReadLine();
                        if (number.Length < 9)
                        {
                            Console.WriteLine("Incorrect format");
                        }
                        else
                        {
                            Console.WriteLine("Insert name");
                            var name = Console.ReadLine();

                            if (name.Length < 3)
                            {
                                Console.WriteLine("Name must contain at least 3 characters.");
                            }
                            else
                            {
                                var newContact = new Contact(name, number);
                                phoneBook.AddContact(newContact);
                                Console.WriteLine("Contact has been added.");
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Insert number");
                        var numberToSearch = Console.ReadLine();
                        phoneBook.DisplayContact(numberToSearch);
                        break;
                    case "3":
                        Console.WriteLine("Insert name");
                        var nameToSearch = Console.ReadLine();
                        phoneBook.DisplayContactName(nameToSearch);
                        break;
                    case "4":
                        phoneBook.DisplayAllContacts();
                        break;
                    case "5":
                        Console.WriteLine("Insert search phrase");
                        var searchPhrase = Console.ReadLine();
                        phoneBook.DisplayMatchingContacts(searchPhrase);
                        break;
                    case "6":
                        Console.WriteLine("Insert name");
                        var contactToRemove = Console.ReadLine();
                        phoneBook.RemoveContact(contactToRemove);
                        break;
                    case "q":
                        return;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
                Console.WriteLine("What would you like to do? Press 'q' to close.");
                userInput = Console.ReadLine();
            }
        }
    }
}
