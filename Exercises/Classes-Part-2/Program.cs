//Classes part 2 exercises

// TODO: Test your exercise solutions with print statements here.

using Classes_Part_2;

Student student = new("Paulo");

Console.WriteLine(student.ToString());

student.AddGrade(3, 4);
Console.WriteLine(student.ToString());

student.AddGrade(4, 3);
Console.WriteLine(student.ToString());
