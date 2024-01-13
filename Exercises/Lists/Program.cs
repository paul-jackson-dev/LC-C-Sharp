//Exercises: Control Flow & Collections

//TODO: Write your code for List Practice below:

List<int> numbers = new List<int> { 1, 1, 2, 3, 5, 8, 1, 1, 2, 3, 5, 8 };

Console.WriteLine(sumMethod(numbers));

string sentence = @"I would not, could not, in a box. I would not, could not with a fox.
I will not eat them in a house. I will not eat them with a mouse.";
string[] sentenceArray = sentence.Split(' ');
foreach (string s in sentenceArray)
{
    Console.WriteLine(s);
}
Console.WriteLine("1 --------------------------------");

List<string> stringList = new List<string>(sentenceArray);
Console.WriteLine(stringList.GetType());
foreach (string s in stringList)
{
    Console.WriteLine(s);
}

Console.WriteLine("2 --------------------------------");
printFive(stringList);



static void printFive(List<string> stringList)
{
    foreach (string word in stringList)
    {
        if (Equals(word.Length, 3))
        {
            Console.WriteLine(word);
        }
    }
}




static int sumMethod(List<int> numbers)
{
    int sum = 0;
    foreach (int number in numbers)
    {
        if (number % 2 == 0)
        {
            sum += number;
        }
    }
    return sum;
}
