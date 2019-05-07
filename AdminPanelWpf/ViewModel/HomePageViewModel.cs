using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.ViewModel
{
    class HomePageViewModel : BaseViewModel
    {
        private string mainText = $"Legyen szép napod {Globals.ActualUser.NickName}!";

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
