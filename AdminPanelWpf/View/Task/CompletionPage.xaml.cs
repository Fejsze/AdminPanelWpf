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
    /// Interaction logic for Completion.xaml
    /// </summary>
    public partial class CompletionPage : Page
    {
        int Point { get; set; }
        DockPanel dpNew = new DockPanel();
        public CompletionPage(string text, int point)
        {
            InitializeComponent();
            this.Point = point;
            Task(text);
            sp.Children.Add(dpNew);
        }
        
        private void Task(string text)
        {
            if (text.Contains("#"))
            {

                Button button = new Button()
                {
                    Height = 25
                    ,Content = "Ellenőrzés",
                };
                dpNew.Children.Add(button);

                button.Click += Button_Click;

                int firstIndex = 0;
                int nextIndex = 0;
                while (firstIndex != -1)
                {
                    firstIndex = text.IndexOf('#', 0);
                    nextIndex = text.IndexOf('#', firstIndex + 1);

                    Label l = new Label
                    {
                        Content = text.Substring(0, (firstIndex == -1) ? text.Length : firstIndex - 1),
                        Height = 25,
                    };
                    dpNew.Children.Add(l);

                    if (firstIndex != -1)
                    {

                        TextBox tb = new TextBox
                        {
                            Tag = text.Substring(firstIndex + 1, nextIndex - firstIndex - 1),
                            MinWidth = 62,
                            MaxHeight = 25
                        };
                        text = text.Substring(nextIndex + 1);
                        dpNew.Children.Add(tb);
                    }
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool l = true;
            foreach (var children in dpNew.Children)
            {
                if (children.GetType() == typeof(TextBox))
                {
                    var x = (children as TextBox);
                    if (x.Text != x.Tag.ToString())
                        l = false;
                }
            }
            if (!l)
                MessageBox.Show("Nem");
            else
                MessageBox.Show("Igen");
        }
    }
}
