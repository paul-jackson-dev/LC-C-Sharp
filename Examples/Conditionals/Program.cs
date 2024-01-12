//-------- Else If Example -----------

Console.WriteLine("\n -------- Else If Example -------- \n");

Console.WriteLine("Enter a grade: ");
string gradeString = Console.ReadLine();
int grade = int.Parse(gradeString);
if (grade < 60)
{
    Console.WriteLine('F');
}
else if (grade < 70)
{
    Console.WriteLine('D');
}
else if (grade < 80)
{
    Console.WriteLine('C');
}
else if (grade < 90)
{
    Console.WriteLine('B');
}
else
{
    Console.WriteLine('A');
}



//-------- Switch Example -----------

Console.WriteLine("\n -------- Switch Example -------- \n");

Console.WriteLine("Enter an integer: ");
string dayString = Console.ReadLine();
int dayNum = int.Parse(dayString);

string day;
switch (dayNum)
{
    case 0:
        day = "Sunday";
        break;
    case 1:
        day = "Monday";
        break;
    case 2:
        day = "Tuesday";
        break;
    case 3:
        day = "Wednesday";
        break;
    case 4:
        day = "Thursday";
        break;
    case 5:
        day = "Friday";
        break;
    case 6:
        day = "Saturday";
        break;
    default:
        // in this example, this block runs if none of the above blocks match
        day = "Int does not correspond to a day of the week";
        break;
}
Console.WriteLine(day);


// Fallthrough Example ------------------

Console.WriteLine("\n -------- Fallthrough Example -------- \n");

Console.WriteLine("Enter an integer: ");
string newDayString = Console.ReadLine();
int newDayNum = int.Parse(newDayString);

string weekZone;
switch (newDayNum)
{
    case 0:
        weekZone = "Weekend";
        break;
    case 1:
    case 2:
    case 3:
    case 4:
    case 5:
        weekZone = "Week Day";
        break;
    case 6:
        weekZone = "Weekend";
        break;
    default:
        // in this example, this block runs if none of the above blocks match
        weekZone = "Int does not correspond to a day of the week";
        break;
}
Console.WriteLine(weekZone);