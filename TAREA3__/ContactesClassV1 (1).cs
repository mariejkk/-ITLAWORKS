

//JHOKAIME MARIE ALVAREZ SANTANA
//2025-0921

using static System.Console;

WriteLine("WELCOME TO MY CONTACT LIST");

bool running = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> favorites = new Dictionary<int, bool>();

while (running)
{
    try
    {
        WriteLine("\n" + new string('=', 120));
        WriteLine("1. ADD CONTACT     2. VIEW CONTACTS    3. SEARCH CONTACTS    4. EDIT CONTACTS   5. DELETE CONTACTS    6. EXIT");
        WriteLine(new string('=', 120));
        WriteLine("Enter the number of your choice ");

        int typeOption = Convert.ToInt32(ReadLine());

        switch (typeOption)
        {
            //--ADD CONTACTS--
            case 1:
                try
                {
                    WriteLine("Enter the person's first name:");
                    string name = ReadLine();
                    WriteLine("Enter the person's last name:");
                    string lastname = ReadLine();
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

                    var id = ids.Count + 1;
                    ids.Add(id);
                    names.Add(id, name);
                    lastnames.Add(id, lastname);
                    addresses.Add(id, address);
                    telephones.Add(id, phone);
                    emails.Add(id, email);
                    ages.Add(id, age);
                    favorites.Add(id, isFavorite);

                    WriteLine("\nContact added successfully!");
                }
                catch (Exception ex)
                {
                    WriteLine($"Error adding contact: {ex.Message}");
                }
                break;

            //--VIEW CONTACTS--
            case 2:
                try
                {
                    if (ids.Count == 0)
                    {
                        WriteLine("There are no registered contacts.");
                        break;
                    }

                    WriteLine($"{"ID",-5} {"First Name",-15} {"Last Name",-15} {"Address",-20} {"Phone",-15} {"Email",-25} {"Age",-5} {"Favorite",-12}");
                    WriteLine(new string('_', 120));

                    foreach (var id in ids)
                    {
                        string isFavoriteStr = favorites[id] ? "Yes" : "No";
                        WriteLine($"{id,-5} {names[id],-15} {lastnames[id],-15} {addresses[id],-20} {telephones[id],-15} {emails[id],-25} {ages[id],-5} {isFavoriteStr,-12}");
                    }
                }
                catch (Exception ex)
                {
                    WriteLine($"Error displaying contacts: {ex.Message}");
                }
                break;


            //SEARCH CONTACTS
            case 3:
                try
                {
                    WriteLine("1. Search by First Name");
                    WriteLine("2. Search by Last Name");
                    WriteLine("3. Search by Phone");
                    WriteLine("Enter the number of the option:");

                    int searchOption = Convert.ToInt32(ReadLine());
                    WriteLine("Enter the search term:");
                    string searchTerm = ReadLine().ToLower();

                    List<int> foundIds = new List<int>();

                    switch (searchOption)
                    {
                        case 1:
                            foreach (var id in ids)
                            {
                                if (names[id].ToLower().Contains(searchTerm))
                                    foundIds.Add(id);
                            }
                            break;
                        case 2:
                            foreach (var id in ids)
                            {
                                if (lastnames[id].ToLower().Contains(searchTerm))
                                    foundIds.Add(id);
                            }
                            break;
                        case 3:
                            foreach (var id in ids)
                            {
                                if (telephones[id].Contains(searchTerm))
                                    foundIds.Add(id);
                            }
                            break;
                        default:
                            WriteLine("Invalid option.");
                            break;
                    }

                    if (foundIds.Count == 0)
                    {
                        WriteLine("No contacts found.");
                        break;
                    }

                    WriteLine($"\nFound {foundIds.Count} contact(s):");
                    WriteLine($"{"ID",-5} {"First Name",-15} {"Last Name",-15} {"Address",-20} {"Phone",-15} {"Email",-25} {"Age",-5} {"Favorite",-12}");
                    WriteLine(new string('_', 120));

                    foreach (var id in foundIds)
                    {
                        string isFavoriteStr = favorites[id] ? "Yes" : "No";
                        WriteLine($"{id,-5} {names[id],-15} {lastnames[id],-15} {addresses[id],-20} {telephones[id],-15} {emails[id],-25} {ages[id],-5} {isFavoriteStr,-12}");
                    }
                }
                catch (Exception ex)
                {
                    WriteLine($"Error searching contact: {ex.Message}");
                }
                break;

            //EDIT CONTACTS
            case 4:
                try
                {

                    if (ids.Count == 0)
                    {
                        WriteLine("There are no contacts to edit.");
                        break;
                    }

                    WriteLine("Enter the ID of the contact to edit:");
                    int idToModify = Convert.ToInt32(ReadLine());

                    if (!ids.Contains(idToModify))
                    {
                        WriteLine("The specified ID does not exist.");
                        break;
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
                            WriteLine($"Current name: {names[idToModify]}");
                            WriteLine("Enter the new first name:");
                            names[idToModify] = ReadLine();
                            break;
                        case 2:
                            WriteLine($"Current last name: {lastnames[idToModify]}");
                            WriteLine("Enter the new last name:");
                            lastnames[idToModify] = ReadLine();
                            break;
                        case 3:
                            WriteLine($"Current address: {addresses[idToModify]}");
                            WriteLine("Enter the new address:");
                            addresses[idToModify] = ReadLine();
                            break;
                        case 4:
                            WriteLine($"Current phone: {telephones[idToModify]}");
                            WriteLine("Enter the new phone:");
                            telephones[idToModify] = ReadLine();
                            break;
                        case 5:
                            WriteLine($"Current email: {emails[idToModify]}");
                            WriteLine("Enter the new email:");
                            emails[idToModify] = ReadLine();
                            break;
                        case 6:
                            WriteLine($"Current age: {ages[idToModify]}");
                            WriteLine("Enter the new age:");
                            ages[idToModify] = Convert.ToInt32(ReadLine());
                            break;
                        case 7:
                            WriteLine($"Current favorite status: {(favorites[idToModify] ? "Yes" : "No")}");
                            WriteLine("Enter 1 for Yes, 2 for No:");
                            favorites[idToModify] = Convert.ToInt32(ReadLine()) == 1;
                            break;
                        case 8:
                            WriteLine("Enter the new first name:");
                            names[idToModify] = ReadLine();
                            WriteLine("Enter the new last name:");
                            lastnames[idToModify] = ReadLine();
                            WriteLine("Enter the new address:");
                            addresses[idToModify] = ReadLine();
                            WriteLine("Enter the new phone:");
                            telephones[idToModify] = ReadLine();
                            WriteLine("Enter the new email:");
                            emails[idToModify] = ReadLine();
                            WriteLine("Enter the new age:");
                            ages[idToModify] = Convert.ToInt32(ReadLine());
                            WriteLine("Enter 1 for Yes, 2 for No (Favorite):");
                            favorites[idToModify] = Convert.ToInt32(ReadLine()) == 1;
                            break;
                        default:
                            WriteLine("Invalid option.");
                            break;
                    }

                    WriteLine("\nContact updated successfully!");
                }
                catch (Exception ex)
                {
                    WriteLine($"Error editing contact: {ex.Message}");
                }
                break;

            //DELETE CONTACTS
            case 5:
                try
                {

                    if (ids.Count == 0)
                    {
                        WriteLine("There are no contacts to delete.");
                        break;
                    }

                    WriteLine("Enter the ID of the contact to delete:");
                    int idToDelete = Convert.ToInt32(ReadLine());

                    if (!ids.Contains(idToDelete))
                    {
                        WriteLine("The specified ID does not exist.");
                        break;
                    }

                    WriteLine($"\nAre you sure you want to delete {names[idToDelete]} {lastnames[idToDelete]}'s contact?");
                    WriteLine("1. Yes, 2. No");
                    int confirmation = Convert.ToInt32(ReadLine());

                    if (confirmation == 1)
                    {
                        ids.Remove(idToDelete);
                        names.Remove(idToDelete);
                        lastnames.Remove(idToDelete);
                        addresses.Remove(idToDelete);
                        telephones.Remove(idToDelete);
                        emails.Remove(idToDelete);
                        ages.Remove(idToDelete);
                        favorites.Remove(idToDelete);

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
                break;

            //EXIT
            case 6:
                running = false;
                WriteLine("THANK YPU FOR USING MY CONTACT LIST. ");
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
