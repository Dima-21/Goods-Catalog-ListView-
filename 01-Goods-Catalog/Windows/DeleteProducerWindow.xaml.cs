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
    /// Interaction logic for DeleteProducerWindow.xaml
    /// </summary>
    public partial class DeleteProducerWindow : Window
    {
        public DeleteProducerWindow()
        {
            InitializeComponent();
        }

        const string path1 = @"..\..\Data\Producers.xml";
        const string path2 = @"..\..\Data\Products.xml";
        //private String DeleteCategory()
        //{
        //    int k = listCategories.SelectedIndex;
        //    XmlDataProvider xdp = new XmlDataProvider();
        //    XDocument doc = XDocument.Load(path1);
        //    XElement root = doc.Element("root");
        //    var categories = root.Elements("category");

        //    if (categories != null && k > 0)
        //    {
        //        var delCategory = categories.ToList()[k];
        //        CategoryName = delCategory.Attribute("name").Value;
        //        delCategory.Remove();
        //        doc.Save(path1);
        //        return delCategory.Attribute("id").Value;
        //    }
        //    return String.Empty;
        //}

        public String ProducerName { get; set; }
        private String DeleteProducers()
        {
            int k = listProducers.SelectedIndex;
            XDocument doc = XDocument.Load(path1);
            XElement root = doc.Element("root");
            var producers = root.Elements("producer");

            if (producers != null && k > 0)
            {
                var delProducers = producers.ToList()[k];
                ProducerName = delProducers.Attribute("name").Value;
                delProducers.Remove();
                doc.Save(path1);
                return delProducers.Attribute("id").Value;
            }
            return String.Empty;
        }

        private void DeleteProducts(string pid)
        {
            XDocument doc = XDocument.Load(path2);
            XElement root = doc.Element("root");
            var products = root.Elements("product");
            var delProducts = products.Where(x => x.Attribute("pid").Value == pid);

            if (delProducts != null)
            {
                delProducts.Remove();
                doc.Save(path2);
            }
        }

      

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            // DELETE PRODUCERS
            string pid = DeleteProducers();
            //

            if (pid == String.Empty)
                return;

            // DELETE PRODUCTS
            DeleteProducts(pid);
            //

            MessageBox.Show($"Категория <{ProducerName}> успешно удалена");
            this.DialogResult = true;
        }
    }
}
