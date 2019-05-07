using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model.Task
{
    /// <summary>
    /// Felelet-választós feladat adatmodelle.
    /// </summary>
    class Multiple_choice
    {
        /// <summary>
        ///     Multiple_choice osztály konstruktora
        /// </summary>
        /// <param name="Question">Kérdés (string)</param>
        /// <param name="GoodAnswer">Jó válasz (string)</param>
        /// <param name="Answers">Válasz lehetőségek (string[])</param>
        /// <param name="Point">Feladatért járó pont (int)</param>
        public Multiple_choice(string Question, string GoodAnswer, string[] Answers, int Point)
        {
            this.Question = Question;
            this.GoodAnswer = GoodAnswer;
            this.Answers = Answers.ToList();
            this.Point = Point;
        }

        public string Question { get; set; }
        public string GoodAnswer { get; set; }
        public int Point { get; set; }
        public List<string> Answers { get; set; }
    }
}
