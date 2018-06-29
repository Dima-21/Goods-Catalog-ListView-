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

        public int Price { get; set; }

        public TicketWindow(string n, int num, string p)
        {
            InitializeComponent();
            for (int i = 1; i <= num; i++)
                nums.Items.Add(i);
            name.Text = n;
            Price = Int32.Parse(p);
            nums.SelectedIndex = 0;
        }

        private void nums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            price.Text = (Price * (nums.SelectedIndex + 1)).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String path = @"..\..\Data\Products.xml";
            XDocument doc = XDocument.Load(path);
            XElement root = doc.Element("root");
            var products = root.Elements("product");
            var editProduct = products.FirstOrDefault(x => x.Attribute("name").Value == name.Text);

            int num = Int32.Parse(editProduct.Attribute("num").Value);
            num -= nums.SelectedIndex + 1;
            editProduct.SetAttributeValue("num", num);
            doc.Save(path);
            MessageBox.Show("Товар успешно куплен! Спасибо за покупку!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
        }
    }
}
