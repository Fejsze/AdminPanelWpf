using LearningApp.ViewModel.Task;
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
using System.Windows.Shapes;

namespace LearningApp.View.Task
{
    /// <summary>
    /// Interaction logic for MainTaskWindow.xaml
    /// </summary>
    public partial class MainTaskWindow : Window
    {
        public MainTaskWindow()
        {
            DataContext = new MainTaskViewModel();
            InitializeComponent();
        }
    }
}
