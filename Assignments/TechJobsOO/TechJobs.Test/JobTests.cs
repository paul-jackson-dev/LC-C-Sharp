
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace TechJobs.Tests
{


    [TestClass]
    public class JobTests
    {
        //Testing Objects
        //initalize your testing objects here

        Job job1 = new Job();

        Job job2 = new Job();

        Job job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

        Job job4 = new Job("", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));


        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.IsFalse(job1.Id == job2.Id);
            Assert.IsTrue(job1.Id + 1 == job2.Id);

        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual(job3.Name, "Product tester");
            Assert.AreEqual(job3.EmployerName.Value, "ACME");
            Assert.AreEqual(job3.EmployerLocation.Value, "Desert");
            Assert.AreEqual(job3.JobType.Value, "Quality control");
            Assert.AreEqual(job3.JobCoreCompetency.Value, "Persistence");

        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(job1.Equals(job2));
        }

        [TestMethod]
        public void TestToStringStartsAndEndsWithNewLine()
        {
            string returnedString = job3.ToString();
            char[] chars = returnedString.ToCharArray();

            Assert.AreEqual(chars[0], '\n'); // first
            Assert.AreEqual(chars[chars.Length - 1], '\n'); // last
        }

        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
            string returnedString = job3.ToString();

            StringBuilder desiredString = new StringBuilder(); // more efficient than using a regular string object since strings are immutable
            desiredString.Append("\n");
            desiredString.Append("ID: " + job3.Id + "\n");
            desiredString.Append("Name: Product tester\n");
            desiredString.Append("Employer: ACME\n");
            desiredString.Append("Location: Desert\n");
            desiredString.Append("Position Type: Quality control\n");
            desiredString.Append("Core Competency: Persistence\n");
            desiredString.Append("\n");

            Assert.AreEqual(returnedString, desiredString.ToString());
        }

        [TestMethod]
        public void TestToStringHandlesEmptyField()
        {
            string returnedString = job4.ToString();

            StringBuilder desiredString = new StringBuilder(); // more efficient than using a regular string object since strings are immutable
            desiredString.Append("\n");
            desiredString.Append("ID: " + job4.Id + "\n");
            desiredString.Append("Name: Data not available\n");
            desiredString.Append("Employer: Data not available\n");
            desiredString.Append("Location: Data not available\n");
            desiredString.Append("Position Type: Data not available\n");
            desiredString.Append("Core Competency: Data not available\n");
            desiredString.Append("\n");

            Assert.AreEqual(returnedString, desiredString.ToString());
        }
    }
}

