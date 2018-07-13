
using _01_Goods_Catalog.Models;
using _01_Goods_Catalog.ViewModels;
using _01_Goods_Catalog.Windows;
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
using System.Xml;

namespace _01_Goods_Catalog.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {      
            InitializeComponent();
            this.DataContext = new ProductViewModels();
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == String.Empty)
            {
                MessageBox.Show("Вы не выбрали товар из списка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                TicketWindow win = new TicketWindow(name.Text, Int32.Parse(num.Text), price.Text);
                if (win.ShowDialog() == true)
                {}
            }
        }

        private void deleteCategory_Click(object sender, RoutedEventArgs e)
        {
            DeleteCategoryWindow delwin = new DeleteCategoryWindow();
            if(delwin.ShowDialog() == true)
            { }
        }

        private void addProducer_Click(object sender, RoutedEventArgs e)
        {
            AddProducerWindow addwin = new AddProducerWindow();
            if (addwin.ShowDialog() == true)
            { }
        }

        private void deleteProducer_Click(object sender, RoutedEventArgs e)
        {
            DeleteProducerWindow delwin = new DeleteProducerWindow();
            if (delwin.ShowDialog() == true)
            { }
        }

        private void delProduct_Click(object sender, RoutedEventArgs e)
        {
            DeleteProductWindow delwin = new DeleteProductWindow();
            if (delwin.ShowDialog() == true)
            { }
        }

        private void editProduct_Click(object sender, RoutedEventArgs e)
        {
            EditProductWindow edwin = new EditProductWindow();
            if (edwin.ShowDialog() == true)
            { }
        }

        private void productList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var Vm = (DataContext as ProductViewModels);
            Product p = (DataContext as ProductViewModels).SelectedProduct;
            
        }
    }
}
