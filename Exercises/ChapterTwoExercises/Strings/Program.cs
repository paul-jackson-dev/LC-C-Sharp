string sentence = @"Alice was beginning to get very tired of sitting by her sister on the
bank, and of having nothing to do: once or twice she had peeped into the
book her sister was reading, but it had no pictures or conversations in
it, 'and what is the use of a book,' thought Alice 'without pictures or
conversation?'";

Console.WriteLine(sentence);
Console.WriteLine("what word do you want to search for? ");
string word = Console.ReadLine().ToLower(); //returns a string
sentence = sentence.ToLower();


if (sentence.IndexOf(word) != -1)
{
    Console.WriteLine("Your word is at index " + sentence.IndexOf(word).ToString() + " and has a length of " + word.Length.ToString() + " characters");
}
else
{
    Console.WriteLine("Your word is not in the sentence.");
}