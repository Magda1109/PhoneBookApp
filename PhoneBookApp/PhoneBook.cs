using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookApp
{
    class PhoneBook
    {
        public List<Contact> Contacts = new List<Contact>();
        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void CheckNumberAndName(string number, string name)
        {
            if (!(number.Length == 9 && number.All(char.IsDigit)))
            {
                Console.WriteLine("Incorrect number format.");
            }
            else if (name.Length < 3)
            {
                Console.WriteLine("Name must contain at least 3 characters. \nContact has not been added. Please try again.");
            }
            else
            {
                var newContact = new Contact(name, number);
                AddContact(newContact);
                Console.WriteLine("Contact has been added.");
            }
        }

        public void RemoveContact(string name)
        {
            var contactToRemove = Contacts.FirstOrDefault(x => x.Name == name);

            if (contactToRemove != null)
            {
                Contacts.Remove(contactToRemove);
                Console.WriteLine("Contact has been removed");
            }
            else
            {
                Console.WriteLine("Incorrect name.");
            }
        }

        private void DisplayContactDetails(Contact contact)
        {
            Console.WriteLine($"Contact: {contact.Name}, {contact.Number}");
        }

        private void DisplayContactsDetails(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                DisplayContactDetails(contact);
            }
        }

        public void DisplayContact(string number)
        {
            var contact = Contacts.FirstOrDefault(c => c.Number == number);

            if (contact == null)
            {
                Console.WriteLine("Contact not found");
            }
            else
            {
                DisplayContactDetails(contact);
            }
        }

        public void DisplayContactName(string name)
        {
            var contact = Contacts.FirstOrDefault(c => c.Name == name);

            if (contact == null)
            {
                Console.WriteLine("Contact not found");
            }
            else
            {
                DisplayContactDetails(contact);
            }
        }

        public void DisplayAllContacts()
        {
            if (Contacts.Count > 0)
            {
                DisplayContactsDetails(Contacts);
            }
            else
            {
                Console.WriteLine("No contacts to display.");
            }
        }

        public void DisplayMatchingContacts(string searchPhrase)
        {
            var matchingContacts = Contacts.Where(c => c.Name.Contains(searchPhrase)).ToList();

            if (matchingContacts.Count == 0)
            {
                Console.WriteLine("There is no such contact.");
            }
            else
            {
                DisplayContactsDetails(matchingContacts);
            }
        }
    }
}