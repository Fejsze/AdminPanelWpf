using LearningApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LearningApp.ViewModel
{
    public class MainViewModel : BaseViewModel
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
        
        public ICommand ButtonCommand { get; set; }
        
        public MainViewModel()
        {
            this.DisplayPage = new LoginPage();
            (this.DisplayPage.DataContext as LoginPageViewModel).OnEventRaisedLog += MainViewModel_OnEventRaised;
            (this.DisplayPage.DataContext as LoginPageViewModel).OnEventRaisedReg += MainViewModel_onEventRaised2;
        }

        private void MainViewModel_OnEventRaised(object sender, EventArgs e)
        {
            this.DisplayPage = new FormAdminPanelPage();
            (this.DisplayPage.DataContext as FormAdminPanelViewModel).onEventRaised += MainViewModel_onEventRaised;
        }

        private void MainViewModel_onEventRaised(object sender, EventArgs e)
        {
            this.DisplayPage = new LoginPage();
            (this.DisplayPage.DataContext as LoginPageViewModel).OnEventRaisedLog += MainViewModel_OnEventRaised;
        }

        private void MainViewModel_onEventRaised2(object sender, EventArgs e)
        {
            this.DisplayPage = new RegistrationPage();
        }
    }
}
