using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuiz
{
    internal class TrueFalse : QuestionAnswer
    {
        public TrueFalse(string question, List<string> answers, List<string> choices) : base(question, answers, choices)
        {
        }
    }
}
