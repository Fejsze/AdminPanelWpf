using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model.Task
{ 
    /// <summary>
    ///     Igaz-Hamis feladat adatmodelle.
    /// </summary>
    public class TrueFalseModel
    {
        /// <summary>
        ///     TrueFalseModel osztály konstruktora.
        /// </summary>
        /// <param name="Question">Kérdés (strin)</param>
        /// <param name="GoodAnswer">Jó válasz (string)</param>
        /// <param name="Poit">Feladatért járó pont</param>
        public TrueFalseModel(string Question, string GoodAnswer, int Point)
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
