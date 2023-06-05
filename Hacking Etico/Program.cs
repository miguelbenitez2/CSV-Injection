using System;
using Hacking_Etico;
using System.IO;
using System.Text;

class Program
{

    static void Main(string[] args)
    {
        string filePath = "test.csv";

        List<ValueClass> list = new List<ValueClass>();

        // Example users
        ValueClass user1 = new ValueClass("-Miguel", "23452");
        ValueClass user2 = new ValueClass("\t++Alma", "45gerg");
        ValueClass user3 = new ValueClass("==\nChichilla", "werg434");
        ValueClass user4 = new ValueClass("@@Paco", "34g43");

        list.Add(user1);
        list.Add(user2);
        list.Add(user3);
        list.Add(user4);

        // You can add users
        //list = AddUserToList(list);
        //list = AddUserToList(list);
        //list = AddUserToList(list);
        //list = AddUserToList(list);

        // CSV Injection Validation
        list = Validation(list);

        foreach (var info in list)
        {
            Console.WriteLine($"Name {info.name} --- ID {info.id}");
        }

        MakeCSV(filePath, list);
        
    }

    // Validation method 
    public static List<ValueClass> Validation(List<ValueClass> list)
    {
        foreach (var info in list)
        {
            //Value Name
            while (info.name.StartsWith("+") || info.name.StartsWith("-") || info.name.StartsWith("=")
                || info.name.StartsWith("@") || info.name.StartsWith("\n") ||info.name.StartsWith("\t")
                || info.name.StartsWith(";"))
            {
                info.name = info.name.Substring(1);
            }

            //Value ID
            while (info.id.StartsWith("-") || info.id.StartsWith("=") || info.id.StartsWith("@")
                || info.id.StartsWith("+") || info.id.StartsWith("\n")
                || info.id.StartsWith("\t") || info.id.StartsWith(";"))
            {
                info.id = info.id.Substring(1);
            }
        }

        return list;
    }

    public static List<ValueClass> AddUserToList(List<ValueClass> list)
    {
        ValueClass valueClass = new ValueClass("", "");

        Console.WriteLine("User name: ");
        valueClass.name = Console.ReadLine();

        Console.WriteLine("User ID: ");
        valueClass.id = Console.ReadLine();

        list.Add(valueClass);

        return list;

    }

    public static void MakeCSV(string file, List<ValueClass> info)
    {
        StringBuilder output = new StringBuilder();
        string separator = ";";

        // Make the headers of csv file with the separator
        String[] headings = { "Name", "ID" };
        output.AppendLine(string.Join(separator, headings));

        foreach (var value in info)
        {
            String[] newLine = { value.name, value.id };
            output.AppendLine(string.Join(separator, newLine));

            // Alternatively, we can format the row using string.Format
            //string newLine = string.Format("{0}, {1}", value.name, value.id);
            //output.AppendLine(string.Join(separator, newLine));
        }

        // Write all the data to the file
        try
        {
            File.Delete(file);
            File.AppendAllText(file, output.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message} -- Data could not be written to the CSV file.");
            return;
        }

    }

}