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
    /// Interaction logic for PairingWindow.xaml
    /// </summary>
    public partial class PairingWindow : Window
    {
        public PairingWindow(Dictionary<string, string> iKerdesek, List<string> iValaszok)
        {
            InitializeComponent();

            DockPanel DockPanel1 = new DockPanel();
            DockPanel1.VerticalAlignment = VerticalAlignment.Top;
            DockPanel1.HorizontalAlignment = HorizontalAlignment.Center;
            np.Children.Add(DockPanel1);

            DockPanel DockPanel2 = new DockPanel();
            DockPanel2.VerticalAlignment = VerticalAlignment.Center;
            DockPanel2.HorizontalAlignment = HorizontalAlignment.Center;
            np.Children.Add(DockPanel2);

            foreach (var x in iKerdesek)
            {
                Label l = new Label
                {
                    Content = x.Key,
                    MaxHeight = 35,
                    Width = 100,
                };
                DockPanel1.Children.Add(l);

                ComboBox cb = new ComboBox
                {
                    Name = x.Key,
                    ItemsSource = new List<string>(iValaszok),
                    MaxHeight = 20,
                    Width = 100,
                };
                DockPanel2.Children.Add(cb);
            }
        }
    }
}
