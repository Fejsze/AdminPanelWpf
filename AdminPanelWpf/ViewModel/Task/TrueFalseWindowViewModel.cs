using LearningApp.Model.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearningApp.ViewModel.Task
{
    class TrueFalsePageViewModel : BaseViewModel
    {
        TrueFalseModel trueFalseM;
        private string question;

        public TrueFalsePageViewModel(string topic, string lesson)
        {
             trueFalseM = new TrueFalseModel("Az int szoveges valtozo?", "igen");
            question = trueFalseM.Question;

            TrueCommand = new RelayCommand(o => TrueClick(o));
            FalseCommand = new RelayCommand(o => FalseClick(o));
        }

        public string Question { get => question; set => question = value; }
        public ICommand TrueCommand { get; set; }
        public ICommand FalseCommand { get; set; }


        private void TrueClick(object sender)
        {
        }
        private void FalseClick(object sender)
        {
        }
    }
}
