using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your birthdate (MM/dd/yyyy): ");
        string birthdateInput = Console.ReadLine();

        if (!Regex.IsMatch(birthdateInput, @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$"))
        {
            Console.WriteLine("Invalid birthdate format. Please use MM/dd/yyyy.");
            return;
        }

        DateTime birthdate = DateTime.ParseExact(birthdateInput, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        int age = DateTime.Now.Year - birthdate.Year;
        if (DateTime.Now.DayOfYear < birthdate.DayOfYear)
        {
            age--;
        }

        Console.WriteLine($"Hello, {name}! You are {age} years old.");

        string userInfo = $"Name: {name}\nBirthdate: {birthdate.ToShortDateString()}\nAge: {age}";
        File.WriteAllText("user_info.txt", userInfo);
        Console.WriteLine("User information saved to user_info.txt.");

        
        string fileContents = File.ReadAllText("user_info.txt");
        Console.WriteLine("\nContents of user_info.txt:");
        Console.WriteLine(fileContents);

        Console.Write("\nEnter a directory path to list files: ");
        string directoryPath = Console.ReadLine();

        if (Directory.Exists(directoryPath))
        {
            Console.WriteLine("Files in directory:");
            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
        else
        {
            Console.WriteLine("Directory does not exist.");
        }

        Console.Write("\nEnter a string to format to title case: ");
        string inputString = Console.ReadLine();
        string titleCaseString = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(inputString.ToLower());
        Console.WriteLine($"Title case: {titleCaseString}");

        GC.Collect();
        Console.WriteLine("Garbage collection has been triggered.");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
