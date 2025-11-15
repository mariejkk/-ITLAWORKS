
//JHOKAIME MARIE ALVAREZ SANTANA
//MATRICULA 2025-0921

using System;
using System.Collections.Generic;
using System.Linq;

namespace PatientRegistrySystem
{
    //CLASE PACIENTE
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string IdNumber { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Patient(int id, string firstName, string lastName, int age, string idNumber, string phone, string address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IdNumber = idNumber;
            Phone = phone;
            Address = address;
            RegistrationDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"ID: {Id} | {FirstName} {LastName} | Age: {Age} | ID Number: {IdNumber} | Phone: {Phone}";
        }

        public string ShowDetails()
        {
            return $"\n=== PATIENT DETAILS ===\n" +
                   $"ID: {Id}\n" +
                   $"Name: {FirstName} {LastName}\n" +
                   $"Age: {Age} years old\n" +
                   $"ID Number: {IdNumber}\n" +
                   $"Phone: {Phone}\n" +
                   $"Address: {Address}\n" +
                   $"Registration Date: {RegistrationDate:MM/dd/yyyy HH:mm}\n" +
                   $"=======================";
        }
    }

    //CLASE PARA GESTIONAR PACIENTES ;)
    public class PatientManager
    {
        private List<Patient> patients;
        private int nextId;

        public PatientManager()
        {
            patients = new List<Patient>();
            nextId = 1;
        }

        public void AddPatient(string firstName, string lastName, int age, string idNumber, string phone, string address)
        {
            Patient newPatient = new Patient(nextId++, firstName, lastName, age, idNumber, phone, address);
            patients.Add(newPatient);
            Console.WriteLine("\n Patient registered successfully!");
        }

        public void ListPatients()
        {
            if (patients.Count == 0)
            {
                Console.WriteLine("\n No patients registered.");
                return;
            }

            Console.WriteLine("\n=== PATIENT LIST ===");
            foreach (var patient in patients)
            {
                Console.WriteLine(patient.ToString());
            }
            Console.WriteLine($"\nTotal: {patients.Count} patient(s)");
        }

        public void SearchPatient(int id)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);
            if (patient != null)
            {
                Console.WriteLine(patient.ShowDetails());
            }
            else
            {
                Console.WriteLine($"\n No patient found with ID {id}");
            }
        }

        public void SearchByIdNumber(string idNumber)
        {
            var patient = patients.FirstOrDefault(p => p.IdNumber == idNumber);
            if (patient != null)
            {
                Console.WriteLine(patient.ShowDetails());
            }
            else
            {
                Console.WriteLine($"\n No patient found with ID Number {idNumber}");
            }
        }

        public void DeletePatient(int id)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);
            if (patient != null)
            {
                patients.Remove(patient);
                Console.WriteLine("\n Patient deleted successfully!");
            }
            else
            {
                Console.WriteLine($"\n No patient found with ID {id}");
            }
        }

        public void UpdatePatient(int id, string firstName, string lastName, int age, string idNumber, string phone, string address)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);
            if (patient != null)
            {
                patient.FirstName = firstName;
                patient.LastName = lastName;
                patient.Age = age;
                patient.IdNumber = idNumber;
                patient.Phone = phone;
                patient.Address = address;
                Console.WriteLine("\n Patient updated successfully!");
            }
            else
            {
                Console.WriteLine($"\n No patient found with ID {id}");
            }
        }
    }

    // CLASE PARA VALIDAR ENTRADAS
    public class Validator
    {
        public static int ReadInteger(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine(" Error: You must enter a valid integer greater than 0.");
                }
            }
        }

        public static string ReadText(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine(" Error: This field cannot be empty.");
                }
            }
        }

        public static int ReadMenuOption(int min, int max)
        {
            while (true)
            {
                Console.Write("\nSelect an option: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int option) && option >= min && option <= max)
                {
                    return option;
                }
                else
                {
                    Console.WriteLine($" Error: You must enter a number between {min} and {max}.");
                }
            }
        }
    }

    //  //CLASE PRINCIPAL DEL PROGRAMA
    class Program
    {
        static void Main(string[] args)
        {
            PatientManager manager = new PatientManager();
            bool continueRunning = true;

            Console.WriteLine("╔═════════════════════════════════════════════════╗");
            Console.WriteLine("║             PATIENT REGISTRY SYSTEM             ║");
            Console.WriteLine("╚═════════════════════════════════════════════════╝");

            while (continueRunning)
            {
                ShowMenu();
                int option = Validator.ReadMenuOption(1, 7);

                switch (option)
                {
                    case 1:
                        RegisterPatient(manager);
                        break;
                    case 2:
                        manager.ListPatients();
                        break;
                    case 3:
                        SearchPatientById(manager);
                        break;
                    case 4:
                        SearchPatientByIdNumber(manager);
                        break;
                    case 5:
                        UpdatePatient(manager);
                        break;
                    case 6:
                        DeletePatient(manager);
                        break;
                    case 7:
                        continueRunning = false;
                        Console.WriteLine("\nGoodbye! Thank you for using the system.");
                        break;
                }

                if (continueRunning)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("╔═════════════════════════════════════════════════╗");
            Console.WriteLine("║                    MAIN MENU                    ║");
            Console.WriteLine("╠═════════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. REGISTRER NEW PATIENT                        ║");
            Console.WriteLine("║ 2. LIST ALL PATIENTS                            ║");
            Console.WriteLine("║ 3. SEARCH PATIENT BY ID                         ║");
            Console.WriteLine("║ 4. SEARCH PATIENT BU PERSONAL ID NUMBER         ║");
            Console.WriteLine("║ 5. UPDATE PATIENT INFORMATION                   ║");
            Console.WriteLine("║ 6. DELETE PATIENT                               ║");
            Console.WriteLine("║ 7. EXIT                                         ║");
            Console.WriteLine("╚═════════════════════════════════════════════════╝");
        }

        static void RegisterPatient(PatientManager manager)
        {
            Console.WriteLine("\n=== REGISTER NEW PATIENT ===");

            string firstName = Validator.ReadText("First Name: ");
            string lastName = Validator.ReadText("Last Name: ");
            int age = Validator.ReadInteger("Age: ");
            string idNumber = Validator.ReadText("ID Number: ");
            string phone = Validator.ReadText("Phone: ");
            string address = Validator.ReadText("Address: ");

            manager.AddPatient(firstName, lastName, age, idNumber, phone, address);
        }

        static void SearchPatientById(PatientManager manager)
        {
            int id = Validator.ReadInteger("\nEnter the patient ID: ");
            manager.SearchPatient(id);
        }

        static void SearchPatientByIdNumber(PatientManager manager)
        {
            string idNumber = Validator.ReadText("\nEnter the patient ID number: ");
            manager.SearchByIdNumber(idNumber);
        }

        static void UpdatePatient(PatientManager manager)
        {
            int id = Validator.ReadInteger("\nEnter the ID of the patient to update: ");

            Console.WriteLine("\nEnter the new data:");
            string firstName = Validator.ReadText("First Name: ");
            string lastName = Validator.ReadText("Last Name: ");
            int age = Validator.ReadInteger("Age: ");
            string idNumber = Validator.ReadText("ID Number: ");
            string phone = Validator.ReadText("Phone: ");
            string address = Validator.ReadText("Address: ");

            manager.UpdatePatient(id, firstName, lastName, age, idNumber, phone, address);
        }

        static void DeletePatient(PatientManager manager)
        {
            int id = Validator.ReadInteger("\nEnter the ID of the patient to delete: ");
            manager.DeletePatient(id);
        }
    }
}
