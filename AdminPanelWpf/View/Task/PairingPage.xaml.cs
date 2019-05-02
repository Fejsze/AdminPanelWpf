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
    public partial class PairingPage : Page
    {
        public PairingPage(Dictionary<string, string> iKerdesek, List<string> iValaszok)
        {
            InitializeComponent();

            Grid DynamicGrid = new Grid
            {
                Width = 400,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                //ShowGridLines = true,
                Background = new SolidColorBrush(Colors.BlanchedAlmond)
            };

            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);
                
            int s = 0;
            foreach (var x in iKerdesek)
            {
                RowDefinition gridRow1 = new RowDefinition
                {
                    Height = new GridLength(45)
                };
                DynamicGrid.RowDefinitions.Add(gridRow1);
                
                Label l = new Label
                {
                    Content = x.Key,
                    MaxHeight = 35,
                    Width = 100,
                };
                Grid.SetRow(l, s);
                Grid.SetColumn(l, 0);
                DynamicGrid.Children.Add(l);

                ComboBox cb = new ComboBox
                {
                    Name = x.Key,
                    ItemsSource = new List<string>(iValaszok),
                    MaxHeight = 20,
                    Width = 100,
                };
                Grid.SetRow(cb, s);
                Grid.SetColumn(cb, 1);
                DynamicGrid.Children.Add(cb);
                s++;
            }
            // Display grid into a Window
            ng.Children.Add(DynamicGrid);
        }
    }
}
