using System;
using Hacking_Etico;

class Program
{
    static void Main(string[] args)
    {
        List<ValueClass> list = new List<ValueClass>();

        ValueClass value1 = new ValueClass("@+Miguel", "1009");
        ValueClass value2 = new ValueClass("=-Alma", "==3445");
        ValueClass value3 = new ValueClass("+-Pepe", "@@23456");
        ValueClass value4 = new ValueClass("=@Manolo", "++23556");
        ValueClass value5 = new ValueClass("\nJijuile", "\t--234");

        list.Add(value1);
        list.Add(value2);
        list.Add(value3);
        list.Add(value4);
        list.Add(value5);

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

        foreach (var info in list)
        {
            Console.WriteLine($"Name {info.name} --- ID {info.id}");
        }
        
    }
}