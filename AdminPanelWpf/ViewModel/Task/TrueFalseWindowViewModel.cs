using LearningApp.Model.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LearningApp.ViewModel.Task
{
    class TrueFalsePageViewModel : BaseViewModel
    {
        /// <summary>
        ///     TrueFalsePageViewModel konstruktora.
        /// </summary>
        /// <param name="trueFalseModel">TrueFalseModel típúst kér be.</param>
        public TrueFalsePageViewModel(TrueFalseModel trueFalseModel)
        {
            trueFalseM = trueFalseModel;
            Point = trueFalseM.Point;
            question = trueFalseM.Question;

            TrueCommand = new RelayCommand(o => TrueClick(o));
            FalseCommand = new RelayCommand(o => FalseClick(o));
        }

        TrueFalseModel trueFalseM;
        public int Point;
        private string question;
        private bool isVisibleTrueButton = true;
        private bool isVisibleFalseButton = true;

        public string Question
        {
            get => question; set
            {
                question = value;
            }
        }
        public bool IsVisibleTrueButton
        {
            get => isVisibleTrueButton; set
            {
                isVisibleTrueButton = value;
                NotifyPropertyChanged("IsVisibletrueButton");
            }
        }
        public bool IsVisibleFalseButton
        {
            get => isVisibleFalseButton; set
            {
                isVisibleFalseButton = value;
                NotifyPropertyChanged("IsVisibleFalseButton");
            }
        }
        public ICommand TrueCommand { get; set; }
        public ICommand FalseCommand { get; set; }

        private void TrueClick(object sender)
        {
            if (trueFalseM.GoodAnswer == "igaz")
            {
                Globals.ActualPoints++;
                ButtonVisibility();
            } else ButtonVisibility();
        }

        private void FalseClick(object sender)
        {
            if (trueFalseM.GoodAnswer == "hamis")
            {
                Globals.ActualPoints += Point;
                ButtonVisibility();
            } else ButtonVisibility();
        }

        private void ButtonVisibility()
        {
            IsVisibleFalseButton = false;
            IsVisibleTrueButton = false;
        }
    }
}
