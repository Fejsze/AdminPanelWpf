using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LearningApp.ViewModel
{
    class RegistrationPageViewModel : BaseViewModel
    {
        public RegistrationPageViewModel()
        {
            RegistrationCommand = new RelayCommand(RegistrationCommandClick);
            PrivacyStatementCommand = new RelayCommand(PrivacyStatementCommandClick);
            ExitCommand = new RelayCommand(o => ExitClick(o));
        }

        public event EventHandler onEventRaised;
        public ICommand ExitCommand { get; set; }
        public ICommand RegistrationCommand { get; set; }
        public ICommand PrivacyStatementCommand { get; set; }

        #region Variables
        private string userName;
        private string nickName;
        private string email;
        private string emailAgain;
        private string password;
        private string passwordAgain;
        private string reminder;
        private bool isSelected;
        #endregion

        #region Properties
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                NotifyPropertyChanged("UserName");
            }
        }
        public string NickName
        {
            get => nickName;
            set
            {
                nickName = value;
                NotifyPropertyChanged("NickName");
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }
        public string EmailAgain { get => emailAgain;
            set
            {
                emailAgain = value;
                NotifyPropertyChanged("EmailAgain");
            }
        }
        public string PasswordAgain
        {
            get => passwordAgain;
            set
            {
                passwordAgain = value;
                NotifyPropertyChanged("PasswordAgain");
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }
        public string Reminder
        {
            get => reminder;
            set
            {
                reminder = value;
                NotifyPropertyChanged("Reminder");
            }
        }
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }
        #endregion

        private void PrivacyStatementCommandClick(object o)
        {
            SqlConnectionHandler sqlConnection = new SqlConnectionHandler();
            sqlConnection.Open();
            MessageBox.Show(sqlConnection.SelectPrivacyStatement());
        }

        /// <summary>
        ///     Regisztrációs gomb eseménye. Adatok ellenőrzése, adatbázisra kiírás meghívása.
        /// </summary>
        private void RegistrationCommandClick(object parameter)
        {
            var passwordContainer = parameter as IHavePassword;
            if (passwordContainer != null)
            {
                var secureString = passwordContainer.Password;
                this.Password = Utilities.ConvertToUnsecureString(secureString);
                var secureString2 = passwordContainer.Password;
                this.PasswordAgain = Utilities.ConvertToUnsecureString(secureString2);
            }
            if (IsSelected)
            {
                if (Password == PasswordAgain)
                {
                    if (Email == EmailAgain)
                    {
                        SqlConnectionHandler conn = new SqlConnectionHandler();
                        try
                        {
                            conn.Open();
                            if (conn.InsertUser(userName, nickName, password, email, Reminder)) MessageBox.Show("Sikeres regisztráció!");
                            else MessageBox.Show("Sikertelen regisztráció!");
                        }
                        catch (Exception )
                        {
                            MessageBox.Show("Hiba, kérem próbálja újra!");
                        }
                    }
                    else MessageBox.Show("Hiba, az email címek nem egyeznek! Kérem próbálja újra!");
                }
                else MessageBox.Show("Hiba, a jelszavak nem egyeznek! Kérem próbálja újra!");
            }
            else MessageBox.Show("Kérem fogadja el az adatvédelmi nyilatkozatot!");
        }

        private void ExitClick(object sender)
        {
            if (onEventRaised != null)
                onEventRaised(this, null);
        }
    }
}
