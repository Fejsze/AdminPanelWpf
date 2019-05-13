using LearningApp.SQL;
using LearningApp.View.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LearningApp.ViewModel.Task
{
    class MainTaskViewModel : BaseViewModel
    {
        public MainTaskViewModel(/*string topic*/)
        {
            SubmitAnswerCommand = new RelayCommand(o => SubmitAnswerClick(o));
            TasksSQLSelects lessonsSQLSelects = new TasksSQLSelects();
            Globals.ActualTasks = lessonsSQLSelects.SelectTask("Console Application");
            Globals.ActualTasksDefault = Globals.ActualTasks;
            this.DisplayPage = Globals.NextTask();
        }

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

        private static void GlobalsSetup(TasksSQLSelects lessonsSQLSelects)
        {
            Globals.ActualPoints = 0;
            Globals.ActualTasks = lessonsSQLSelects.SelectTask("alapok I");
            List<Page> lessons = lessonsSQLSelects.SelectTask("alapok II");
            for (int i = 0; i < lessons.Count; i++)
            {
                Globals.ActualTasks.Add(lessons[i]);
            }
        }

        /// <summary>
        ///     Feladat megerősítése gomb eseménye.
        /// </summary>
        private void SubmitAnswerClick(object o)
        {
            Page next = Globals.NextTask();
            if (next != null)
            {
                this.DisplayPage = next;
            }
            else
            {
                int error = Globals.LvLUp();
                if (error == 1)
                {
                    MessageBox.Show("Gratullok szintet léptél!");
                }
                else if (error == 0)
                {
                    MessageBox.Show("A teszten nem mentél át. Kérlek próbáld újra!");
                }
                else
                {
                    MessageBox.Show("Hiba történt! Kérlek töltsd ki újból a tesztet!");
                }
                CloseAction();
            }
        }

        private static Page pairingPage()
        {
            List<string> answers = new List<string>() { "v1", "v2", "v3", "v4", "v5" };
            Dictionary<string, string> questions = new Dictionary<string, string>() { { "kerdes1", "v1" }, { "kerdes2", "v2" }, { "kerdes3", "v3" } };
            return new PairingPage(questions, answers, 50);
        }
    }
}
