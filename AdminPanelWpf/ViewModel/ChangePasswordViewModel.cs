using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearningApp.ViewModel
{
    class ChangePasswordViewModel : BaseViewModel
    {
        private string oldPassword;
        public string OldPassword
        {
            get { return oldPassword; }
            set
            {
                oldPassword = value;
                NotifyPropertyChanged("OldPassword");
            }
        }
        private string newPassword;
        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                newPassword = value;
                NotifyPropertyChanged("NewPassword");
            }
        }

        private string newPasswordAgain;
        public string NewPasswordAgain
        {
            get { return newPasswordAgain; }
            set
            {
                newPasswordAgain = value;
                NotifyPropertyChanged("NewPasswordAgain");
            }
        }
        public ICommand ButtonCommand { get; set; }

        public ChangePasswordViewModel()
        {
            ButtonCommand = new RelayCommand(o => SubmitButtonClick(o));
        }

        private void SubmitButtonClick(object sender)
        {
            if(OldPassword == Globals.ActualUser.Password)
            {
                if(this.NewPassword == this.NewPasswordAgain)
                {
                    SqlConnectionHandler conn = new SqlConnectionHandler();
                    conn.Open();
                    conn.UpdatePassword(Globals.ActualUser.GeneratedID, this.NewPassword);
                }
                else
                    System.Windows.MessageBox.Show("Nem egyezik a jelszó");
            }
            else
                System.Windows.MessageBox.Show("Nem jó az eddigi jelszó");
        }
    }
}
