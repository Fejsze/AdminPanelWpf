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
    /// Interaction logic for Multiple_choiceWindow.xaml
    /// </summary>
    public partial class Multiple_choiceWindow : Window
    {
        public Multiple_choiceWindow(string topic, string lessons)
        {
            InitializeComponent();
            this.DataContext = new Multiple_choiceWindowViewModel(topic, lessons);
        }
    }
}
