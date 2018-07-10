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
using System.Xml;

namespace _01_Goods_Catalog.Windows
{
    /// <summary>
    /// Interaction logic for InfoProductWindow.xaml
    /// </summary>
    public partial class InfoProductWindow : Window
    {
        public XmlElement Elem { get; set; }
        public InfoProductWindow()
        {
            InitializeComponent();
        }
    }
}
