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
using System.Xml.Linq;

namespace _01_Goods_Catalog
{
    /// <summary>
    /// Interaction logic for TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        public TicketWindow()
        {
            InitializeComponent();
        }

        public TicketWindow(string n, int num, string p)
        {
            InitializeComponent();
            Binding b = new Binding();
            for (int i = 1; i <= num; i++)
            { 
                nums.Items.Add(i);
            }
            b.Source = Int32.Parse(nums.SelectedItem.ToString()) * Int32.Parse(p);
            b.Path = new PropertyPath(nums.Text);
            name.Text = n;
        }
    }
}
