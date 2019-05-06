using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.ViewModel
{
    class HomePageViewModel : BaseViewModel
    {
        private string mainText = "Kezdőlap";

        public string MainText
        {
            get => mainText; set
            {
                mainText = value;
                NotifyPropertyChanged("MainText");
            }
        }
    }
}
