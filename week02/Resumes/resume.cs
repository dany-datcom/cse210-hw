using System.Collections.Generic;
public class resume
{
    public string _personName;
    public List<job> _jobs = new List<job>();

    public void DisplayResumeDetails()
    {
        Console.WriteLine(_personName);

        foreach (job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}