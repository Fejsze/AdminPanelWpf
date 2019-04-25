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
        private string userName;
        private string nickName;
        private string email;
        private string password;
        private string reminder;

        public string UserName { get => userName; set => userName = value; }
        public string NickName { get => nickName; set => nickName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Reminder { get => reminder; set => reminder = value; }

        public ICommand RegistrationCommand { get; set; }

        public RegistrationPageViewModel()
        {
            RegistrationCommand = new RelayCommand(RegistrationCommandClick);
        }

        private void RegistrationCommandClick(object parameter)
        {
            var passwordContainer = parameter as IHavePassword;
            if (passwordContainer != null)
            {
                var secureString = passwordContainer.Password;
                this.Password = Utilities.ConvertToUnsecureString(secureString);
            }
            SqlConnectionHandler conn = new SqlConnectionHandler();
            try
            {
                conn.Open();
                conn.InsertUser(userName, nickName, password, email, Reminder);
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Hiba, kérem próbálja újra!");
            }
        }
    }
}
