class Program
{
    static void Main(string[] args)
    {
        job job1 = new job();
        job job2 = new job();
        resume myResume = new resume();

        Console.WriteLine("Hello World! This is the Resumes Project.");

        Console.Write("Enter the job title: ");
        job1._jobTitle = Console.ReadLine();

        Console.Write("Enter the company: ");
        job1._company = Console.ReadLine();

        Console.Write("Enter the start year: ");
        job1._startYear = int.Parse(Console.ReadLine());

        Console.Write("Enter the end year: ");
        job1._endYear = int.Parse(Console.ReadLine());

        Console.Write("Enter the job title: ");
        job2._jobTitle = Console.ReadLine();

        Console.Write("Enter the company: ");
        job2._company = Console.ReadLine();

        Console.Write("Enter the start year: ");
        job2._startYear = int.Parse(Console.ReadLine());

        Console.Write("Enter the end year: ");
        job2._endYear = int.Parse(Console.ReadLine());

        myResume._personName = "Dany Jimenez";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        
        myResume.DisplayResumeDetails();
    }
}