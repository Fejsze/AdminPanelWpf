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
        public ICommand TestCommand { get; set; }

        public FormAdminPanelViewModel()
        {
            ChangePasswordCommand = new RelayCommand(o => ChangePasswordClick(o));
            ExitCommand = new RelayCommand(o => ExitClick(o));
            TestCommand = new RelayCommand(o => TestClick(o));
        }

        private void ChangePasswordClick(object sender)
        {
            this.DisplayPage = new ChangePasswordPage();
        }
        private void TestClick(object sender)
        {
            PairingWindow pairingWindow = new PairingWindow("asd#fdsa#asd");
            pairingWindow.Show();

            //pairingWindow.Close();
        }
        private void ExitClick(object sender)
        {
            if (onEventRaised != null)
                onEventRaised(this, null);
        }
    }
}
