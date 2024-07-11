using System;
using System.Collections.Generic;
using System.Linq;

class ContactManager
{
    static List<Contact> contacts = new List<Contact>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Contact Management System:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Delete Contact");
            Console.WriteLine("3. Search Contacts");
            Console.WriteLine("4. View All Contacts");
            Console.WriteLine("5. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    DeleteContact();
                    break;
                case "3":
                    SearchContacts();
                    break;
                case "4":
                    ViewAllContacts();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AddContact()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter phone: ");
        string phone = Console.ReadLine();
        contacts.Add(new Contact { Name = name, Phone = phone });
    }

    static void DeleteContact()
    {
        Console.Write("Enter name of contact to delete: ");
        string name = Console.ReadLine();
        var contact = contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (contact != null)
        {
            contacts.Remove(contact);
            Console.WriteLine("Contact deleted. Press Enter to continue.");
        }
        else
        {
            Console.WriteLine("Contact not found. Press Enter to try again.");
        }
        Console.ReadLine();
    }

    static void SearchContacts()
    {
        Console.Write("Enter name to search: ");
        string name = Console.ReadLine();
        var searchResults = contacts.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        if (searchResults.Any())
        {
            Console.WriteLine("\nSearch Results:");
            foreach (var contact in searchResults)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.Phone}");
            }
        }
        else
        {
            Console.WriteLine("No contacts found.");
        }
        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }

    static void ViewAllContacts()
    {
        Console.Clear();
        Console.WriteLine("All Contacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Name: {contact.Name}, Phone: {contact.Phone}");
        }
        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
}

class Contact
{
    public string Name { get; set; }
    public string Phone { get; set; }
}
