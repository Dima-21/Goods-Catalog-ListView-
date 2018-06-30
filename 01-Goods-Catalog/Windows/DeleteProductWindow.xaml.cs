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
    /// Interaction logic for DeleteProductWindow.xaml
    /// </summary>
    public partial class DeleteProductWindow : Window
    {
        const string path = @"..\..\Data\Products.xml";

        public DeleteProductWindow()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void DeleteProduct()
        {
            XDocument doc = XDocument.Load(path);
            XElement root = doc.Element("root");
            var products = root.Elements("product");
            if (listProduct.SelectedIndex != 0)
            {
                var delProduct = products.ToList()[listProduct.SelectedIndex];

                if (delProduct != null)
                {
                    delProduct.Remove();
                    doc.Save(path);
                }
            }
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteProduct();
            MessageBox.Show("Товар успешно удален", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;

        }
    }
}
