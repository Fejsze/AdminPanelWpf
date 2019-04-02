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
    /// <summary>
    /// Interaction logic for NewFormPage.xaml
    /// </summary>
    public partial class NewFormPage : Page
    {
        public NewFormPage()
        {
            InitializeComponent();

            NewControls();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewControls();
        }

        private void NewControls()
        {
            DockPanel spNew = new DockPanel();
            Button bt = new Button()
            {
                Width = 20,
                Content = "+"
            };
            bt.Click += Button_Click;
            spNew.Children.Add(bt);
            Button bt2 = new Button()
            {
                Width = 20,
                Content = "-"
            };
            bt2.Click += Button_Click_1;
            spNew.Children.Add(bt2);
            Label lb = new Label()
            {
                Content = "Mező neve:"
            };
            spNew.Children.Add(lb);
            TextBox tb = new TextBox()
            {
                Text = "asd",
                Name = "FieldName"
            };
            spNew.Children.Add(tb);
            Label lb2 = new Label()
            {
                Content = "Mező neve:"
            };
            spNew.Children.Add(lb2);
            //TextBox tb2 = new TextBox()
            //{
            //    Text = "asd",
            //    Name = "Type"
            //};
            ComboBox comboBox = new ComboBox()
            {
                Name = "Type",
                ItemsSource = new List<string>() { "a", "b", "c", "d" }
            };
            spNew.Children.Add(comboBox);

            sp.Children.Add(spNew);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = 0;
            int c = 0;
            while(index < sp.Children.Count)
            {
                if (sp.Children[index].GetType() == typeof(DockPanel))
                    c++;
                index++;
            }
            if(c > 1)
            {
                DockPanel asd = ((sender as Button).Parent as DockPanel);
                sp.Children.Remove(asd as UIElement);
            }
        }
        /* TODO: Mentés gombra kerüljön adatbázis-kapcsolat, a sp.Children-en foreach, majd annak a Chiledren-ein is foreach-al végigmenve */
    }
}
