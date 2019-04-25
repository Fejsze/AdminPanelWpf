using LearningApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearningApp.View
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page, IHavePassword
    {
        public RegistrationPage()
        {
            InitializeComponent();
            this.DataContext = new RegistrationPageViewModel();

        }

        public SecureString Password
        {
            get
            {
                return PasswordBox.SecurePassword;
            }
        }
    }
}
