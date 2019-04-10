using LearningApp.Model.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearningApp.ViewModel.Task
{
    class Multiple_choiceWindowViewModel
    {
        Multiple_choice multiple_choiceM;
        Random random = new Random();

        public Multiple_choiceWindowViewModel(string topic, string lesson)
        {
            multiple_choiceM = new Multiple_choice("Az int szoveges valtozo?", "igen", new List<string> {"asd", "Asd", "dsa"});
            Question = multiple_choiceM.Question;
            int r = random.Next(1, 5);
            if (r == 1)
            {
                A1 = multiple_choiceM.GoodAnswer;
                A2 = multiple_choiceM.Answers[0];
                A3 = multiple_choiceM.Answers[1];
                A4 = multiple_choiceM.Answers[2];
            }
            else if (r == 2)
            {
                A2 = multiple_choiceM.GoodAnswer;
                A1 = multiple_choiceM.Answers[0];
                A3 = multiple_choiceM.Answers[1];
                A4 = multiple_choiceM.Answers[2];
            }
            else if (r == 3)
            {
                A3 = multiple_choiceM.GoodAnswer;
                A1 = multiple_choiceM.Answers[0];
                A2 = multiple_choiceM.Answers[1];
                A4 = multiple_choiceM.Answers[2];
            }
            else
            {
                A4 = multiple_choiceM.GoodAnswer;
                A1 = multiple_choiceM.Answers[0];
                A2 = multiple_choiceM.Answers[1];
                A3 = multiple_choiceM.Answers[2];
            }

            AnswerCommand = new RelayCommand(o => AnswerClick(o));
        }

        public string Question { get; set; }
        public ICommand AnswerCommand { get; set; }

        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }

        private void AnswerClick(object sender)
        {
            
        }

    }
}
