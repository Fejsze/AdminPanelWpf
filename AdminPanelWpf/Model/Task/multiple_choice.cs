using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model.Task
{
    class Multiple_choice
    {
        public Multiple_choice(string Question, string GoodAnswer, List<string> Answers)
        {
            this.Question = Question;
            this.GoodAnswer = GoodAnswer;
            this.Answers = Answers;
        }

        public string Question { get; set; }
        public string GoodAnswer { get; set; }
        public List<string> Answers { get; set; }
    }
}
