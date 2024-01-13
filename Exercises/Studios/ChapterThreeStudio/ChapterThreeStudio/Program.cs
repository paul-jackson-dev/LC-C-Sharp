string sentence = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.";
sentence = sentence.ToLower();
//Console.WriteLine(sentence);
char[] charArray = sentence.ToCharArray();

Dictionary<char, int> charDictionary = new Dictionary<char, int>();

foreach (char c in charArray)
{
    if (!charDictionary.ContainsKey(c))
    {
        charDictionary[c] = 0;
    }
    charDictionary[c]++;
}

foreach (KeyValuePair<char, int> kvp in charDictionary)
{
    Console.WriteLine(kvp.Key + " : " + kvp.Value);
}
