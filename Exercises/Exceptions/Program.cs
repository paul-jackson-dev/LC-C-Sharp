// --------- Divide By Zero! ----------

/* 
static double Divide(double x, double y)
{
    // Write your code here!
}
*/
using System;

static double Divide(double a, double b)
{
    if (a == 0)
    {
        throw new ArgumentOutOfRangeException("a is 0 and cannot be divided");
    }
    return a / b;
}


// Test out your Divide() function here!
Console.WriteLine(Divide(1, 1));
double div;
try
{
    div = Divide(0, 1);
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}
finally
{
    div = 0;
}
Console.WriteLine(div);


// --------- Test Student Labs ----------

/*
static int CheckFileExtension(string fileName)
{
    // Write your code here!
}
*/
static int CheckFileExtension(string filename)
{
    if (filename == "" || filename == null)
    {
        throw new ArgumentNullException("filename is null or empty");
    }
    int num = 0;
    if (filename.EndsWith(".cs"))
    {
        num = 1;
    }
    return num;
}

// Test out your CheckFileExtension() function here!

Dictionary<string, string> students = new Dictionary<string, string>();
students.Add("Carl", "Program.cs");
students.Add("Brad", null);
students.Add("tom", "");
students.Add("Elizabeth", "MyCode.cs");

foreach (KeyValuePair<string, string> kvp in students)
{
    int grade = 0;
    string name = kvp.Key;
    try
    {
        grade = CheckFileExtension(kvp.Value);
    }
    catch (Exception e) { Console.WriteLine(e); }

    Console.WriteLine($"{name} : {grade}");
}



