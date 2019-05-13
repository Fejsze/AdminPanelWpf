using LearningApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            LoginButtonCommand = new RelayCommand(SubmitButtonClick);
            RegistrationButtonCommand = new RelayCommand(o => RegistrationButtonClick(o));
        }

        private void SubmitButtonClick(object parameter)
        {
            var passwordContainer = parameter as IHavePassword;
            if (passwordContainer != null)
            {
                var secureString = passwordContainer.Password;
                this.Password = Utilities.ConvertToUnsecureString(secureString);
            }
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
                    System.Windows.MessageBox.Show("Nem megfelelő felhasználó vagy jelszó!");

            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Hiba, kérem próbálja újra!");
            }
            //OnEventRaisedLog(this, null);
        }
        
        private void RegistrationButtonClick(object sender)
        {
            try
            {
                OnEventRaisedReg(new RegistrationPageViewModel(), null);
            }
            catch (Exception){}
        }
    }
}
