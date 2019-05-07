using LearningApp.Model.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearningApp.ViewModel.Task
{
    class Multiple_choicePageViewModel : BaseViewModel
    {
        /// <summary>
        ///     Multiple_choicePageViewModel konstruktora
        /// </summary>
        /// <param name="mc">Multiple_choice típust vár bemenetnek.</param>
        public Multiple_choicePageViewModel(Multiple_choice mc)
        {
            AnswerCommand1 = AnswerCommand2 = AnswerCommand3 = AnswerCommand4 = new RelayCommand(o => GoodAnswerClick(o));
            multiple_choiceM = mc;
            Point = multiple_choiceM.Point;
            Question = multiple_choiceM.Question;
            Setup();
        }

        Random random = new Random();
        Multiple_choice multiple_choiceM;
        public int Point;
        private bool ansButtonSVis = true;

        private void Setup()
        {
            int r = random.Next(1, 5);
            if (r == 1)
            {
                AnswerCommand1 = new RelayCommand(o => BadAnswerClick(o));
                A1 = multiple_choiceM.GoodAnswer;
                A2 = multiple_choiceM.Answers[0];
                A3 = multiple_choiceM.Answers[1];
                A4 = multiple_choiceM.Answers[2];
            }
            else if (r == 2)
            {
                AnswerCommand2 = new RelayCommand(o => BadAnswerClick(o));
                A2 = multiple_choiceM.GoodAnswer;
                A1 = multiple_choiceM.Answers[0];
                A3 = multiple_choiceM.Answers[1];
                A4 = multiple_choiceM.Answers[2];
            }
            else if (r == 3)
            {
                AnswerCommand3 = new RelayCommand(o => BadAnswerClick(o));
                A3 = multiple_choiceM.GoodAnswer;
                A1 = multiple_choiceM.Answers[0];
                A2 = multiple_choiceM.Answers[1];
                A4 = multiple_choiceM.Answers[2];
            }
            else
            {
                AnswerCommand4 = new RelayCommand(o => BadAnswerClick(o));
                A4 = multiple_choiceM.GoodAnswer;
                A1 = multiple_choiceM.Answers[0];
                A2 = multiple_choiceM.Answers[1];
                A3 = multiple_choiceM.Answers[2];
            }
        }
        
        public string Question { get; set; }

        #region CommandsRegion
        public ICommand AnswerCommand1 { get; set; }
        public ICommand AnswerCommand2 { get; set; }
        public ICommand AnswerCommand3 { get; set; }
        public ICommand AnswerCommand4 { get; set; }
        #endregion

        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
        public bool AnsButtonSVis
        {
            get => ansButtonSVis; set
            {
                ansButtonSVis = value;
                NotifyPropertyChanged("AnsButtonSVis");
            }
        }

        private void BadAnswerClick(object sender)
        {
            AnsButtonSVis = false;
        }
        private void GoodAnswerClick(object sender)
        {
            Globals.ActualPoints += Point;
            AnsButtonSVis = false;
        }
    }
}
