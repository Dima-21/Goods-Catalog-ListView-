﻿using System;
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

namespace _01_Goods_Catalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            int k1 = listCategory.SelectedIndex;
            int k2 = listProducer.SelectedIndex;

            XmlDataProvider xdp = (XmlDataProvider)FindResource("productProvider");
            Binding b = new Binding();

            b.Source = xdp;
            if (k1 > 0 && k2 == 0)
                b.XPath = $"product[@cid={k1}]";
            else if (k1 == 0 && k2 > 0)
                b.XPath = $"product[@pid={k2}]";
            else if(k1 > 0 && k2 > 0)
                b.XPath = $"product[@cid={k1} and @pid={k2}]";
            else
                b.XPath = $"product";
            productList.SetBinding(ListView.ItemsSourceProperty, b);

        }

        private void order_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addcategory_Click(object sender, RoutedEventArgs e)
        {
            AddWindow win = new AddWindow();
            if(win.ShowDialog() == true)
            {
                XmlDataProvider xdp = (XmlDataProvider)FindResource("categoryProvider");
                Binding b = new Binding();
                b.Source = xdp;
                b.XPath = "category";
                listCategory.SetBinding(ComboBox.ItemsSourceProperty, b);
            }
            
        }
    }
}
