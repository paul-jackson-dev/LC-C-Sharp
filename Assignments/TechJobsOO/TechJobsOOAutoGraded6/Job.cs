using System;
using System.Text;
namespace TechJobsOOAutoGraded6
{
    public class Job
    {


        public int Id { get; }
        private static int nextId = 1;
        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Task 3: Add the two necessary constructors.
        public Job()
        {
            Id = nextId;
            nextId++;
        }
        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        // TODO: Task 3: Generate Equals() and GetHashCode() methods.  
        public override bool Equals(object? obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }


        // TODO: Task 5: Generate custom ToString() method.
        //Until you create this method, you will not be able to print a job to the console.

        public override string ToString()
        {
            // StringBuilder didn't like compact .Append with ternary
            string ternaryName = Name != "" ? Name : "Data not available";
            string ternaryEmployer = EmployerName.Value != "" ? EmployerName.Value : "Data not available";
            string ternaryLocation = EmployerLocation.Value != "" ? EmployerLocation.Value : "Data not available";
            string ternaryPosition = JobType.Value != "" ? JobType.Value : "Data not available";
            string ternaryCompetency = JobCoreCompetency.Value != "" ? JobCoreCompetency.Value : "Data not available";

            StringBuilder returnString = new StringBuilder(); // more efficient than using a regular string object since strings are immutable
            returnString.Append("\n");
            returnString.Append("ID: " + Id + "\n");
            returnString.Append("Name: " + ternaryName + "\n");
            returnString.Append("Employer: " + ternaryEmployer + "\n");
            returnString.Append("Location: " + ternaryLocation + "\n");
            returnString.Append("Position Type: " + ternaryPosition + "\n");
            returnString.Append("Core Competency: " + ternaryCompetency + "\n");
            returnString.Append("\n");

            return returnString.ToString();
        }

    }
}

