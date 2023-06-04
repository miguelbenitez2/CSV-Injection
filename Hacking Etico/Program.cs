using System;
using Hacking_Etico;

class Program
{
    static void Main(string[] args)
    {
        List<ValueClass> list = new List<ValueClass>();

        list = AddUserToList(list);

        list = Validation(list);

        foreach (var info in list)
        {
            Console.WriteLine($"Name {info.name} --- ID {info.id}");
        }
        
    }

    // Validation method 
    public static List<ValueClass> Validation(List<ValueClass> list)
    {
        foreach (var info in list)
        {
            //Value Name
            while (info.name.StartsWith("+") || info.name.StartsWith("-") || info.name.StartsWith("=")
                || info.name.StartsWith("@") || info.name.StartsWith("+") || info.name.StartsWith("\n")
                || info.name.StartsWith("\t") || info.name.StartsWith("\n") || info.name.StartsWith(";"))
            {
                info.name = info.name.Substring(1);
            }

            //Value ID
            while (info.id.StartsWith("+") || info.id.StartsWith("-") || info.id.StartsWith("=")
                || info.id.StartsWith("@") || info.id.StartsWith("+") || info.id.StartsWith("\n")
                || info.id.StartsWith("\t") || info.id.StartsWith("\n") || info.id.StartsWith(";"))
            {
                info.id = info.id.Substring(1);
            }
        }

        return list;
    }

    public static List<ValueClass> AddUserToList(List<ValueClass> list)
    {
        ValueClass valueClass = new ValueClass();

        Console.WriteLine("User name: ");
        valueClass.name = Console.ReadLine();

        Console.WriteLine("User ID: ");
        valueClass.id = Console.ReadLine();

        list.Add(valueClass);

        return list;

    }

}