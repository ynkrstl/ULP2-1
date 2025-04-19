using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";
        Random random = new Random();

        using (StreamWriter writer = new StreamWriter(inputFile))
        {
            for (int i = 0; i < 20; i++)
            {
                writer.WriteLine(random.Next(-100, 101));
            }
        }

        int firstOdd = 0;
        bool found = false;

        using (StreamReader reader = new StreamReader(inputFile))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int number = int.Parse(line);
                if (Math.Abs(number) % 2 == 1 && !found)
                {
                    firstOdd = number;
                    found = true;
                }
            }
        }

        using (StreamReader reader = new StreamReader(inputFile))
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int number = int.Parse(line);
                writer.WriteLine(number + firstOdd);
            }
        }

        Console.WriteLine("Файлы успешно обработаны.");
        Console.WriteLine($"Первое нечетное число: {firstOdd}");
    }
}