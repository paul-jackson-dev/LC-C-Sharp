using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuiz
{
    internal class MultipleChoice : QuestionAnswer
    {

        public MultipleChoice(string question, List<string> answers, List<string> choices) : base(question, answers, choices)
        {
        }

    }
}
