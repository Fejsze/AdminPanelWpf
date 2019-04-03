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
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();

            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = 400;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);

            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);

            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(45);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(45);
            DynamicGrid.RowDefinitions.Add(gridRow2);
            DynamicGrid.RowDefinitions.Add(gridRow3);

            // Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "Author Name";
            txtBlock1.FontSize = 14;
            txtBlock1.FontWeight = FontWeights.Bold;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);

            // Add second column header
            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.Text = "Age";
            txtBlock2.FontSize = 14;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 1);
            DynamicGrid.Children.Add(txtBlock1);
            DynamicGrid.Children.Add(txtBlock2);

            // Create first Row
            TextBlock authorText = new TextBlock();
            authorText.Text = "Mahesh Chand";
            authorText.FontSize = 12;
            authorText.FontWeight = FontWeights.Bold;
            Grid.SetRow(authorText, 1);
            Grid.SetColumn(authorText, 0);
            TextBlock ageText = new TextBlock();
            ageText.Text = "33";
            ageText.FontSize = 12;
            ageText.FontWeight = FontWeights.Bold;
            Grid.SetRow(ageText, 1);
            Grid.SetColumn(ageText, 1);
            
            // Add first row to Grid
            DynamicGrid.Children.Add(authorText);
            DynamicGrid.Children.Add(ageText);
            
            // Display grid into a Window
            ng.Children.Add(DynamicGrid);
        }
    }
}
