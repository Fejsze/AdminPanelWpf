using LearningApp.SQL;
using LearningApp.View.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LearningApp.ViewModel.Task
{
    class MainTaskViewModel : BaseViewModel
    {
        public ICommand SubmitAnswerCommand { get; set; }
        public Action CloseAction { get; set; }

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
            SubmitAnswerCommand = new RelayCommand(o => SubmitAnswerClick(o));
            LessonsSQLSelects lessonsSQLSelects = new LessonsSQLSelects();
            Globals.ActualPoints = 0;
            Globals.ActualTasks = lessonsSQLSelects.Multiple_choiceTask("alapok I");
            //Globals.ActualTasks = lessonsSQLSelects.Multiple_choiceTask("alapok II");
            //Globals.ActualTasks = lessonsSQLSelects.Multiple_choiceTask("ConsoleApp I");
            Globals.ActualTasksDefault = Globals.ActualTasks;
            this.DisplayPage = Globals.NextTask();
        }

        private void SubmitAnswerClick(object o)
        {
            Page next = Globals.NextTask();
            if (next != null)
            {
                this.DisplayPage = next;
            }
            else CloseAction();
        }

        private static Page pairingPage()
        {
            List<string> answers = new List<string>() { "v1", "v2", "v3", "v4", "v5" };
            Dictionary<string, string> questions = new Dictionary<string, string>() { { "kerdes1", "v1" }, { "kerdes2", "v2" }, { "kerdes3", "v3" } };
            return new PairingPage(questions, answers);
        }
    }
}
