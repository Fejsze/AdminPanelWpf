using LearningApp.View.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LearningApp.ViewModel.Task
{
    class MainTaskViewModel : BaseViewModel
    {
        private Page _displayPage;
        public Page DisplayPage
        {
            get
            {
                return _displayPage;
            }
            set
            {
                if (Equals(_displayPage, value))
                {
                    return;
                }

                this._displayPage = value;

                NotifyPropertyChanged("DisplayPage");
            }
        }
        public MainTaskViewModel()
        {
            Globals.ActualPionts = 0;
            if (Globals.ActualTasks != null)
            {
                if (Globals.ActualTasks.Count() != 0)
                {
                    Globals.ActualTasks = new List<Page>();
                }
            }
            this.DisplayPage = PageSelector("Párosítós");
        }

        private Page PageSelector(string type)
        {
            switch (type)
            {
                case "Felelet választós":
                    return pairingPage();
                case "Párosítós":
                    return pairingPage();
                case "Igaz-hamis":
                    return pairingPage();
                case "Kiegészítős":
                    return pairingPage();
                default:
                    return null;
            }
        }

        private static Page pairingPage()
        {
            List<string> answers = new List<string>() { "v1", "v2", "v3", "v4", "v5" };
            Dictionary<string, string> questions = new Dictionary<string, string>() { { "kerdes1", "v1" }, { "kerdes2", "v2" }, { "kerdes3", "v3" } };
            return new PairingPage(questions, answers);
        }
    }
}
