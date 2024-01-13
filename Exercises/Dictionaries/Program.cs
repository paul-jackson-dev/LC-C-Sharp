//Exercises: Control Flow & Collections

//TODO: Write your code for Dictionary Practice below:

Console.WriteLine("Hello, Dictionary!");

Dictionary<int, string> students = new Dictionary<int, string>() { { 0, "kev" }, { 1, "reb" }, { 2, "dev" } };

foreach (KeyValuePair<int, string> student in students)
{
    Console.WriteLine(student.Key.ToString() + " : " + student.Value);
}

foreach (int number in students.Keys)
{
    Console.WriteLine(number);
    Console.WriteLine(students[number]);
}

foreach (string name in students.Values)
{
    Console.WriteLine(name);
}