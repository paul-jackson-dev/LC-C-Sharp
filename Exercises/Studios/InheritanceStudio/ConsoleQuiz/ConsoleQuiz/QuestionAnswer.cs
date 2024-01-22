using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuiz
{
    internal class QuestionAnswer
    {
        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public List<string> Choices { get; set; }

        public QuestionAnswer(string question, List<string> answers, List<string> choices)
        {
            Question = question;
            Answers = answers;
            Choices = choices;
        }
    }
}
