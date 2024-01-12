using ChapterOneStudio;

Console.WriteLine("Please enter a radius.");
double radius = double.Parse(Console.ReadLine());
double area = Math.PI * Math.Pow(radius, 2);
Console.WriteLine("The area of your circle is " + area.ToString());

Console.WriteLine(Fun.ShowFun());