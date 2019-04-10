using LearningApp.View;
using LearningApp.View.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LearningApp.ViewModel
{
    class FormAdminPanelViewModel : BaseViewModel
    {
        public event EventHandler onEventRaised;
        private Page displayPage;
        public Page DisplayPage
        {
            get { return displayPage; }
            set
            {
                displayPage = value;
                NotifyPropertyChanged("DisplayPage");
            }
        }

        public ICommand ExitCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        //Completion
        public ICommand TestCommand { get; set; }
        //Pairing
        public ICommand TestCommand2 { get; set; }
        public ICommand TestCommand3 { get; set; }

        public FormAdminPanelViewModel()
        {
            ChangePasswordCommand = new RelayCommand(o => ChangePasswordClick(o));
            ExitCommand = new RelayCommand(o => ExitClick(o));
            TestCommand = new RelayCommand(o => TestClick1(o));
            TestCommand2 = new RelayCommand(o => TestClick2(o));
            TestCommand3 = new RelayCommand(o => TestClick3(o));
        }

        private void ChangePasswordClick(object sender)
        {
            this.DisplayPage = new ChangePasswordPage();
        }
        private void TestClick1(object sender)
        {
            //Completion completionWindow = new Completion("asd#fdsa#asd");
            //completionWindow.Show();

            Test test = new Test();
            test.Show();
        }
        private void TestClick2(object sender)
        {
            PairingWindow pairingWindow = new PairingWindow(new Dictionary<string, string>() { { "kerdes1", "v1" }, { "kerdes2", "v2" }, { "kerdes3", "v3" } }, new List<string>() { "v1", "v2", "v3", "v4", "v5" });
            pairingWindow.Show();
        }
        private void TestClick3(object sender)
        {
            Multiple_choiceWindow multiple_ChoiceWindow = new Multiple_choiceWindow("asd", "asd"); 
            multiple_ChoiceWindow.Show();
        }
        private void ExitClick(object sender)
        {
            if (onEventRaised != null)
                onEventRaised(this, null);
        }
    }
}
