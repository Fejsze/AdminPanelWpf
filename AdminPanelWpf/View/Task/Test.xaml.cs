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
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Center;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Center;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.BlanchedAlmond);

            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);

            RowDefinition gridRow1 = new RowDefinition();
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(45);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(45);
            DynamicGrid.RowDefinitions.Add(gridRow1);
            DynamicGrid.RowDefinitions.Add(gridRow2);
            DynamicGrid.RowDefinitions.Add(gridRow3);

            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "asd";
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);
            DynamicGrid.Children.Add(txtBlock1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.Text = "asd2";
            Grid.SetRow(txtBlock2, 1);
            Grid.SetColumn(txtBlock2, 0);
            DynamicGrid.Children.Add(txtBlock2);

            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.Text = "asd3";
            Grid.SetRow(txtBlock3, 2);
            Grid.SetColumn(txtBlock3, 0);
            DynamicGrid.Children.Add(txtBlock3);

            // Create first Row
            TextBlock authorText = new TextBlock();
            Grid.SetRow(authorText, 1);
            Grid.SetColumn(authorText, 0);
            TextBlock ageText = new TextBlock();
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
