using LearningApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace LearningApp.ViewModel
{
    class LoginPageViewModel : BaseViewModel
    {
        public event EventHandler OnEventRaisedLog;
        public event EventHandler OnEventRaisedReg;


        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged("UserName");
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

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

        public ICommand LoginButtonCommand { get; set; }
        public ICommand RegistrationButtonCommand { get; set; }


        public LoginPageViewModel()
        {
            LoginButtonCommand = new RelayCommand(o => SubmitButtonClick(o));
            RegistrationButtonCommand = new RelayCommand(o => RegistrationButtonClick(o));

        }

        private void SubmitButtonClick(object sender)
        {
            SqlConnectionHandler sql = new SqlConnectionHandler();
            try
            {
                sql.Open();
                var isValid = sql.IsUserValid(this.UserName, this.Password);

                if (isValid)
                {
                    Globals.ActualUser = sql.GetUserData(this.UserName);
                    if (OnEventRaisedLog != null)
                        OnEventRaisedLog(this, null);
                }
                else
                    System.Windows.MessageBox.Show("NEM");

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Csatlakozási hiba, kérem próbálhja újra!");
            }
            //OnEventRaisedLog(this, null);
        }

        private void RegistrationButtonClick(object sender)
        {
            OnEventRaisedReg(new RegistrationPageViewModel(), null);
        }
    }
}
