using ConsoleQuiz;

List<QuestionAnswer> questionAnswers = new();

Checkbox checkbox = new("Enter the number for all that say 'bee', one at a time.", new List<string> { "2", "4" }, new List<string> { "1. fish", "2. bee", "3. dog", "4. bee" });
questionAnswers.Add(checkbox);
MultipleChoice multipleChoice = new("Are you tall?", new List<string> { "1" }, new List<string> { "1. yes", "2. no" });
questionAnswers.Add(multipleChoice);
TrueFalse trueFalse = new("Dune buggys are fun?", new List<string> { "1" }, new List<string> { "1. true", "2. false" });
questionAnswers.Add(trueFalse);

int totalPoints = 0;
int userPoints = 0;
foreach (QuestionAnswer questionAnswer in questionAnswers)
{
    List<string> userAnswers = new List<string>();
    totalPoints += questionAnswer.Answers.Count();
    Console.WriteLine(questionAnswer.Question);
    foreach (string choice in questionAnswer.Choices)
    {
        Console.WriteLine(choice);
    }
    while (userAnswers.Count != questionAnswer.Answers.Count())
    {
        string answer = Console.ReadLine();
        userAnswers.Add(answer);

    }

    // score it
    int i = 0;
    foreach (string answer in questionAnswer.Answers)
    {
        if (answer == userAnswers[i])
        {
            userPoints++;
        }
        i++;
    }
    Console.WriteLine(userPoints.ToString() + " out of " + totalPoints.ToString() + " correct.");

}



