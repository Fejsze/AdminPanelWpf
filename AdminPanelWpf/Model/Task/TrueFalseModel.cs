using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model.Task
{
    public class TrueFalseModel
    {
        public TrueFalseModel(string Question, string GoodAnswer, int Poit)
        {
            this.Question = Question;
            this.GoodAnswer = GoodAnswer;
            this.Point = Point;
        }

        public string Question { get; set; }
        public string GoodAnswer { get; set; }
        public int Point { get; set; }
    }
}
