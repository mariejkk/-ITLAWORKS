
//JHOKAIME MARIE ALVAREZ SANTANA
// 2025-0921

using static System.Console;


WriteLine("--WELCOME TO MY CONTACT LIST--");

bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> favorites = new Dictionary<int, bool>();

while (runing)
{
    WriteLine("\n" + new string('-', 120));
    WriteLine("1. ADD CONTACT     2. VIEW CONTACTS    3. SEARCH CONTACTS     4. EDIT CONTACT   5. DELETE CONTACT    6. EXIT");
    WriteLine(new string('-', 120));
    Write("\nEnter the number of your choice: ");

    int typeOption;
    if (!int.TryParse(ReadLine(), out typeOption))
    {
        WriteLine("Invalid input. Please enter a number between 1 and 6.");
        continue;
    }

    switch (typeOption)
    {
        case 1:
            {
                WriteLine("\n" + new string('=', 40));
                WriteLine("           ADD NEW CONTACT");
                WriteLine(new string('=', 40));

                Write("Enter the person's first name: ");
                string name = ReadLine();

                Write("Enter the person's last name: ");
                string lastname = ReadLine();

                Write("Enter the address: ");
                string address = ReadLine();

                Write("Enter the person's phone: ");
                string phone = ReadLine();

                Write("Enter the person's email: ");
                string email = ReadLine();

                Write("Enter the person's age (in numbers): ");
                int age;
                while (!int.TryParse(ReadLine(), out age))
                {
                    Write("Please enter a valid number: ");
                }

                Write("Specify if it is a best friend (1. Yes / 2. No): ");
                int temp;
                while (!int.TryParse(ReadLine(), out temp) || (temp != 1 && temp != 2))
                {
                    Write("Enter 1 for Yes or 2 for No: ");
                }
                bool isFavorite = temp == 1;

                int id = ids.Count > 0 ? ids.Max() + 1 : 1;
                ids.Add(id);
                names.Add(id, name);
                lastnames.Add(id, lastname);
                addresses.Add(id, address);
                telephones.Add(id, phone);
                emails.Add(id, email);
                ages.Add(id, age);
                favorites.Add(id, isFavorite);

                WriteLine("\nContact successfully added!");
                WriteLine(new string('-', 40));
            }
            break;

        case 2:
            {
                WriteLine("\n" + new string('=', 40));
                WriteLine("           CONTACT LIST");
                WriteLine(new string('=', 40));

                if (ids.Count == 0)
                {
                    WriteLine("No contacts registered.");
                    break;
                }

                WriteLine($"{"ID",-5} {"First Name",-15} {"Last Name",-15} {"Address",-20} {"Phone",-15} {"Email",-25} {"Age",-5} {"Favorites",-12}");
                WriteLine(new string('-', 120));

                foreach (var id in ids)
                {
                    string isFavoriteStr = favorites[id] ? "Yes" : "No";
                    WriteLine($"{id,-5} {names[id],-15} {lastnames[id],-15} {addresses[id],-20} {telephones[id],-15} {emails[id],-25} {ages[id],-5} {isFavoriteStr,-12}");
                }
            }
            break;

        case 3:
            {
                WriteLine("\n" + new string('=', 40));
                WriteLine("           SEARCH CONTACTS");
                WriteLine(new string('=', 40));

                WriteLine("1. Search by first name");
                WriteLine("2. Search by lastname");
                WriteLine("3. Search by phone");
                Write("Enter the number of the Option: ");

                int searchOption;
                if (!int.TryParse(ReadLine(), out searchOption))
                {
                    WriteLine("Invalid option.");
                    break;
                }

                Write("Enter the search term: ");
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
                WriteLine(new string('-', 120));
                WriteLine($"{"ID",-5} {"First Name",-15} {"Last Name",-15} {"Address",-20} {"Phone",-15} {"Email",-25} {"Age",-5} {"Favorites",-12}");
                WriteLine(new string('-', 120));

                foreach (var id in foundIds)
                {
                    string isFavoritesStr = favorites[id] ? "Yes" : "No";
                    WriteLine($"{id,-5} {names[id],-15} {lastnames[id],-15} {addresses[id],-20} {telephones[id],-15} {emails[id],-25} {ages[id],-5} {isFavoritesStr,-12}");
                }
            }
            break;

        case 4:
            {
                WriteLine("\n" + new string('=', 40));
                WriteLine("           EDIT CONTACT");
                WriteLine(new string('=', 40));

                if (ids.Count == 0)
                {
                    WriteLine("No contacts to edit.");
                    break;
                }

                Write("Enter the ID of the contact to edit: ");
                int idToModify;
                if (!int.TryParse(ReadLine(), out idToModify) || !ids.Contains(idToModify))
                {
                    WriteLine("The specified ID does not exist.");
                    break;
                }

                WriteLine("--What do you want to edit?--");
                WriteLine("1. First Name");
                WriteLine("2. Last Name");
                WriteLine("3. Address");
                WriteLine("4. Phone");
                WriteLine("5. Email");
                WriteLine("6. Age");
                WriteLine("7. Is Favorite");
                WriteLine("8. Edit All");

                int modifyOption;
                if (!int.TryParse(ReadLine(), out modifyOption))
                {
                    WriteLine("Invalid option.");
                    break;
                }

                switch (modifyOption)
                {
                    case 1:
                        Write("Enter the new first name: ");
                        names[idToModify] = ReadLine();
                        break;
                    case 2:
                        Write("Enter the new last name: ");
                        lastnames[idToModify] = ReadLine();
                        break;
                    case 3:
                        Write("Enter the new address: ");
                        addresses[idToModify] = ReadLine();
                        break;
                    case 4:
                        Write("Enter the new phone: ");
                        telephones[idToModify] = ReadLine();
                        break;
                    case 5:
                        Write("Enter the new email: ");
                        emails[idToModify] = ReadLine();
                        break;
                    case 6:
                        Write("Enter the new age: ");
                        ages[idToModify] = Convert.ToInt32(ReadLine());
                        break;
                    case 7:
                        Write("Enter 1 for Yes, 2 for No (Favorite): ");
                        favorites[idToModify] = Convert.ToInt32(ReadLine()) == 1;
                        break;
                    case 8:
                        Write("Enter the new first name: ");
                        names[idToModify] = ReadLine();
                        Write("Enter the new last name: ");
                        lastnames[idToModify] = ReadLine();
                        Write("Enter the new address: ");
                        addresses[idToModify] = ReadLine();
                        Write("Enter the new phone: ");
                        telephones[idToModify] = ReadLine();
                        Write("Enter the new email: ");
                        emails[idToModify] = ReadLine();
                        Write("Enter the new age: ");
                        ages[idToModify] = Convert.ToInt32(ReadLine());
                        Write("Enter 1 for Yes, 2 for No (Favorites): ");
                        favorites[idToModify] = Convert.ToInt32(ReadLine()) == 1;
                        break;
                    default:
                        WriteLine("Invalid option.");
                        break;
                }

                WriteLine("\nContact successfully edited!");
                WriteLine(new string('-', 40));
            }
            break;

        case 5:
            {
                WriteLine("\n" + new string('=', 40));
                WriteLine("           DELETE CONTACT");
                WriteLine(new string('=', 40));

                if (ids.Count == 0)
                {
                    WriteLine("No contacts to delete.");
                    break;
                }

                Write("Enter the ID of the contact to delete: ");
                int idToDelete;
                if (!int.TryParse(ReadLine(), out idToDelete) || !ids.Contains(idToDelete))
                {
                    WriteLine("The specified ID does not exist.");
                    break;
                }

                WriteLine($"\nAre you sure you want to delete the contact of {names[idToDelete]} {lastnames[idToDelete]}?");
                Write("1. Yes / 2. No: ");
                int confirmation;
                if (!int.TryParse(ReadLine(), out confirmation) || (confirmation != 1 && confirmation != 2))
                {
                    WriteLine("Invalid input. Operation canceled.");
                    break;
                }

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

                    WriteLine("\nContact successfully deleted!");
                }
                else
                {
                    WriteLine("Operation canceled.");
                }
                WriteLine(new string('-', 40));
            }
            break;

        case 6:
            runing = false;
            WriteLine("\n" + new string('=', 60));
            WriteLine("      THANK YOU FOR USING MY CONTACT LIST");
            WriteLine(new string('=', 60));
            break;

        default:
            WriteLine("Invalid option. Please select an option from 1 to 6.");
            break;
    }
}

