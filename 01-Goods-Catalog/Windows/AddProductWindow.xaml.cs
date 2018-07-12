using _01_Goods_Catalog.ViewModels;
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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {


        public AddProductWindow()
        {
            InitializeComponent();
            this.DataContext = new ProductViewModels();
        }

        private bool Check()
        {
            if (listCategory.SelectedIndex == 0 && listProducer.SelectedIndex == 0 && name.Text == String.Empty &&
               price.Text == String.Empty && num.Text == String.Empty)
                return false;
            return true;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
           if(!Check())
                MessageBox.Show("Заполните все поля", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                this.DialogResult = true;
        }
    }
}
