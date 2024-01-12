using System.Text;

Console.WriteLine("\n -------- For Loop ----------\n");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}


Console.WriteLine("\n -------- Foreach Loop ----------\n");

int[] nums = { 1, 1, 2, 3, 5, 8, 13, 21 };

foreach (int n in nums)
{
    Console.WriteLine(n);
}


Console.WriteLine("\n -------- While Loop ----------\n");

int w = 0;
while (w < 3)
{
    w++;
}

Console.WriteLine(w);

Console.WriteLine("\n -------- Do-While Loop ----------\n");

do
{
    Console.WriteLine("Hello, World");
} while (false);

Console.WriteLine("\n -------- Break Loop ----------\n");

int[] someInts = { 1, 10, 2, 3, 5, 8, 10 };
int searchTerm = 10;
foreach (int oneInt in someInts)
{
    if (oneInt == searchTerm)
    {
        Console.WriteLine("Found it!");
        break;
    }
}


Console.WriteLine("\n -------- Continue Loop ----------\n");

int[] someOtherInts = { 1, 10, 2, 3, 5, 8, 10 };
int newSearchTerm = 10;
foreach (int oneNewInt in someOtherInts)
{
    if (oneNewInt == newSearchTerm)
    {
        Console.WriteLine("Found it!");
        continue;
    }
    Console.WriteLine("Not here");
}


Console.WriteLine("\n -------- Concatenation with a Foreach Loop ----------\n");

string[] arrayOfWords = { "Books", "Cheese", "Trees", "Laughter" };

string finalSentence = "";

foreach (string word in arrayOfWords)
{
    finalSentence += word;
}

Console.WriteLine(finalSentence);

Console.WriteLine("\n -------- Concatenation with StringBuilder and a Loop ----------\n");

StringBuilder newFinalSentence = new StringBuilder();

foreach (string word in arrayOfWords)
{
    newFinalSentence.Append(word);
}

Console.WriteLine(newFinalSentence);