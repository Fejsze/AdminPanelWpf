using LearningApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class LessonsPage : Page
    {
        public LessonsPage(string topic)
        {
            InitializeComponent();
            this.DataContext = new LessonsPageViewModel(topic);
        }
    }
}
