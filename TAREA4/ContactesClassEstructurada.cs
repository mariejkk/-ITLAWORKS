

//JHOKAIME MARIE ALVAREZ SANTANA
//2025-0921

using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        ContactManager manager = new ContactManager();
        manager.Run();
    }
}

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public bool IsFavorite { get; set; }

    public Contact(int id, string firstName, string lastName, string address,
                   string phone, string email, int age, bool isFavorite)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Phone = phone;
        Email = email;
        Age = age;
        IsFavorite = isFavorite;
    }

    public override string ToString()
    {
        string favoriteStr = IsFavorite ? "Yes" : "No";
        return $"{Id,-5} {FirstName,-15} {LastName,-15} {Address,-20} {Phone,-15} {Email,-25} {Age,-5} {favoriteStr,-12}";
    }
}
public class ContactManager
{
    private List<Contact> contacts;
    private int nextId;

    public ContactManager()
    {
        contacts = new List<Contact>();
        nextId = 1;
    }

    public void Run()
    {
        WriteLine("WELCOME TO MY CONTACT LIST");
        bool running = true;

        while (running)
        {
            try
            {
                ShowMenu();
                int option = Convert.ToInt32(ReadLine());

                switch (option)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        ViewContacts();
                        break;
                    case 3:
                        SearchContacts();
                        break;
                    case 4:
                        EditContact();
                        break;
                    case 5:
                        DeleteContact();
                        break;
                    case 6:
                        running = false;
                        WriteLine("THANK YOU FOR USING MY CONTACT LIST.");
                        break;
                    default:
                        WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    private void ShowMenu()
    {
        WriteLine("\n" + new string('=', 120));
        WriteLine("1. ADD CONTACT     2. VIEW CONTACTS    3. SEARCH CONTACTS    4. EDIT CONTACTS   5. DELETE CONTACTS    6. EXIT");
        WriteLine(new string('=', 120));
        WriteLine("Enter the number of your choice ");
    }

    private void AddContact()
    {
        try
        {
            WriteLine("Enter the person's first name:");
            string firstName = ReadLine();
            WriteLine("Enter the person's last name:");
            string lastName = ReadLine();
            WriteLine("Enter the address:");
            string address = ReadLine();
            WriteLine("Enter the phone number:");
            string phone = ReadLine();
            WriteLine("Enter the email address:");
            string email = ReadLine();
            WriteLine("Enter the person's age (numbers only):");
            int age = Convert.ToInt32(ReadLine());
            WriteLine("Is this person a favorite? 1. Yes, 2. No");
            bool isFavorite = Convert.ToInt32(ReadLine()) == 1;

            Contact newContact = new Contact(nextId, firstName, lastName, address,
                                            phone, email, age, isFavorite);
            contacts.Add(newContact);
            nextId++;

            WriteLine("\nContact added successfully!");
        }
        catch (Exception ex)
        {
            WriteLine($"Error adding contact: {ex.Message}");
        }
    }

    private void ViewContacts()
    {
        try
        {
            if (contacts.Count == 0)
            {
                WriteLine("There are no registered contacts.");
                return;
            }

            PrintHeader();
            foreach (var contact in contacts)
            {
                WriteLine(contact.ToString());
            }
        }
        catch (Exception ex)
        {
            WriteLine($"Error displaying contacts: {ex.Message}");
        }
    }

    private void SearchContacts()
    {
        try
        {
            WriteLine("1. Search by First Name");
            WriteLine("2. Search by Last Name");
            WriteLine("3. Search by Phone");
            WriteLine("Enter the number of the option:");

            int searchOption = Convert.ToInt32(ReadLine());
            WriteLine("Enter the search term:");
            string searchTerm = ReadLine().ToLower();

            List<Contact> foundContacts = new List<Contact>();

            switch (searchOption)
            {
                case 1:
                    foundContacts = contacts.FindAll(c => c.FirstName.ToLower().Contains(searchTerm));
                    break;
                case 2:
                    foundContacts = contacts.FindAll(c => c.LastName.ToLower().Contains(searchTerm));
                    break;
                case 3:
                    foundContacts = contacts.FindAll(c => c.Phone.Contains(searchTerm));
                    break;
                default:
                    WriteLine("Invalid option.");
                    return;
            }

            if (foundContacts.Count == 0)
            {
                WriteLine("No contacts found.");
                return;
            }

            WriteLine($"\nFound {foundContacts.Count} contact(s):");
            PrintHeader();
            foreach (var contact in foundContacts)
            {
                WriteLine(contact.ToString());
            }
        }
        catch (Exception ex)
        {
            WriteLine($"Error searching contact: {ex.Message}");
        }
    }

    private void EditContact()
    {
        try
        {
            if (contacts.Count == 0)
            {
                WriteLine("There are no contacts to edit.");
                return;
            }

            WriteLine("Enter the ID of the contact to edit:");
            int idToEdit = Convert.ToInt32(ReadLine());

            Contact contact = contacts.Find(c => c.Id == idToEdit);
            if (contact == null)
            {
                WriteLine("The specified ID does not exist.");
                return;
            }

            WriteLine("\nWhat would you like to edit?");
            WriteLine("1. First Name");
            WriteLine("2. Last Name");
            WriteLine("3. Address");
            WriteLine("4. Phone");
            WriteLine("5. Email");
            WriteLine("6. Age");
            WriteLine("7. Favorite");
            WriteLine("8. Edit All");

            int modifyOption = Convert.ToInt32(ReadLine());

            switch (modifyOption)
            {
                case 1:
                    WriteLine($"Current name: {contact.FirstName}");
                    WriteLine("Enter the new first name:");
                    contact.FirstName = ReadLine();
                    break;
                case 2:
                    WriteLine($"Current last name: {contact.LastName}");
                    WriteLine("Enter the new last name:");
                    contact.LastName = ReadLine();
                    break;
                case 3:
                    WriteLine($"Current address: {contact.Address}");
                    WriteLine("Enter the new address:");
                    contact.Address = ReadLine();
                    break;
                case 4:
                    WriteLine($"Current phone: {contact.Phone}");
                    WriteLine("Enter the new phone:");
                    contact.Phone = ReadLine();
                    break;
                case 5:
                    WriteLine($"Current email: {contact.Email}");
                    WriteLine("Enter the new email:");
                    contact.Email = ReadLine();
                    break;
                case 6:
                    WriteLine($"Current age: {contact.Age}");
                    WriteLine("Enter the new age:");
                    contact.Age = Convert.ToInt32(ReadLine());
                    break;
                case 7:
                    WriteLine($"Current favorite status: {(contact.IsFavorite ? "Yes" : "No")}");
                    WriteLine("Enter 1 for Yes, 2 for No:");
                    contact.IsFavorite = Convert.ToInt32(ReadLine()) == 1;
                    break;
                case 8:
                    WriteLine("Enter the new first name:");
                    contact.FirstName = ReadLine();
                    WriteLine("Enter the new last name:");
                    contact.LastName = ReadLine();
                    WriteLine("Enter the new address:");
                    contact.Address = ReadLine();
                    WriteLine("Enter the new phone:");
                    contact.Phone = ReadLine();
                    WriteLine("Enter the new email:");
                    contact.Email = ReadLine();
                    WriteLine("Enter the new age:");
                    contact.Age = Convert.ToInt32(ReadLine());
                    WriteLine("Enter 1 for Yes, 2 for No (Favorite):");
                    contact.IsFavorite = Convert.ToInt32(ReadLine()) == 1;
                    break;
                default:
                    WriteLine("Invalid option.");
                    return;
            }

            WriteLine("\nContact updated successfully!");
        }
        catch (Exception ex)
        {
            WriteLine($"Error editing contact: {ex.Message}");
        }
    }

    private void DeleteContact()
    {
        try
        {
            if (contacts.Count == 0)
            {
                WriteLine("There are no contacts to delete.");
                return;
            }

            WriteLine("Enter the ID of the contact to delete:");
            int idToDelete = Convert.ToInt32(ReadLine());

            Contact contact = contacts.Find(c => c.Id == idToDelete);
            if (contact == null)
            {
                WriteLine("The specified ID does not exist.");
                return;
            }

            WriteLine($"\nAre you sure you want to delete {contact.FirstName} {contact.LastName}'s contact?");
            WriteLine("1. Yes, 2. No");
            int confirmation = Convert.ToInt32(ReadLine());

            if (confirmation == 1)
            {
                contacts.Remove(contact);
                WriteLine("\nContact deleted successfully!");
            }
            else
            {
                WriteLine("\nOperation canceled.");
            }
        }
        catch (Exception ex)
        {
            WriteLine($"Error deleting contact: {ex.Message}");
        }
    }

    private void PrintHeader()
    {
        WriteLine($"{"ID",-5} {"First Name",-15} {"Last Name",-15} {"Address",-20} {"Phone",-15} {"Email",-25} {"Age",-5} {"Favorite",-12}");
        WriteLine(new string('_', 120));
    }
}