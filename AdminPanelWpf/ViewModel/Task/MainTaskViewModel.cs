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
        public MainTaskViewModel(string topic)
        {
            this.topic = topic;
            SubmitAnswerCommand = new RelayCommand(o => SubmitAnswerClick(o));
            GlobalsSetup(new TasksSQLSelects());
            this.DisplayPage = Globals.NextTask();
        }

        private string topic;
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

        private void GlobalsSetup(TasksSQLSelects lessonsSQLSelects)
        {
            Globals.ActualPoints = 0;
            Globals.ActualTasks = TasksSetup(topic);
            Globals.ActualTasksDefault = Globals.ActualTasks;
        }

        private List<Page> TasksSetup(string topic)
        {
            List<Page> Pages = new List<Page>();
            switch (topic)
            {
                case "Hotkeys":
                    Pages.Add(pairingPage());
                    return Pages;
                case "Változók II":
                    List<Page> p;
                    p = new TasksSQLSelects().SelectTask("alapok I");
                    foreach (var item in p)
                    {
                        Pages.Add(item);
                    }
                    p = null;
                    p = new TasksSQLSelects().SelectTask("alapok II");
                    foreach (var item in p)
                    {
                        Pages.Add(item);
                    }
                    return Pages;
                default:
                    return Pages;
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
