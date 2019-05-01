using LearningApp.Model.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearningApp.ViewModel.Task
{
    class Multiple_choicePageViewModel
    {
        Multiple_choice multiple_choiceM;
        Random random = new Random();

        public Multiple_choicePageViewModel(Multiple_choice mc)
        {
            multiple_choiceM = mc;
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

            BadAnswerCommand = new RelayCommand(o => BadAnswerClick(o));
            GoodAnswerCommand = new RelayCommand(o => GoodAnswerClick(o));
        }

        public string Question { get; set; }
        public ICommand BadAnswerCommand { get; set; }
        public ICommand GoodAnswerCommand { get; set; }

        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }

        private void BadAnswerClick(object sender)
        {

        }
        private void GoodAnswerClick(object sender)
        {
            
        }

    }
}
