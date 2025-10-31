using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.WriteLine(" ");
        Console.WriteLine("Enter your grade porcentage. ");
        string answer = Console.ReadLine();
        int letter = int.Parse(answer);

        string grade = "";
        string sign = "";

        if (letter >= 90)
        {
            grade = "A";
        }
        else if (letter >= 80)
        {
            grade = "B";
        }
        else if (letter >= 70)
        {
            grade = "C";
        }
        else if (letter >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        int lastDigit = letter % 10;

        if (grade != "F" && grade != "A")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        Console.WriteLine($"Your grade is: {grade}{sign}");


        if (letter >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep trying, and you’ll do better next time.");
        }
    }
}

