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
        public ICommand RegistrationCommand { get; set; }

        public RegistrationPageViewModel()
        {
            RegistrationCommand = new RelayCommand(RegistrationCommandClick);
        }

        private void RegistrationCommandClick(object parameter)
        {
            //code
        }
    }
}
