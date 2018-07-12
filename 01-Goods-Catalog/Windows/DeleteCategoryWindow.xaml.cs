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
    /// Interaction logic for DeleteCategoryWindow.xaml
    /// </summary>
    public partial class DeleteCategoryWindow : Window
    {
        const string path1 = @"..\..\Data\Categories.xml";
        const string path2 = @"..\..\Data\Producers.xml";
        const string path3 = @"..\..\Data\Products.xml";

        public String CategoryName { get; set; }

        public DeleteCategoryWindow()
        {
            InitializeComponent();
            this.DataContext = new ProductViewModels();
        }

        private String DeleteCategory()
        {
            int k = listCategories.SelectedIndex;
            XmlDataProvider xdp = new XmlDataProvider();
            XDocument doc = XDocument.Load(path1);
            XElement root = doc.Element("root");
            var categories = root.Elements("category");
          
            if (categories != null && k > 0)
            {
                var delCategory = categories.ToList()[k];
                CategoryName = delCategory.Attribute("name").Value;
                delCategory.Remove();  
                doc.Save(path1);
                return delCategory.Attribute("id").Value;
            }
            return String.Empty;
        }

        private void DeleteProducers(string cid)
        {
            XDocument doc = XDocument.Load(path2);
            XElement root = doc.Element("root");
            var producers = root.Elements("producer");
            var delProducers = producers.Where(x => x.Attribute("cid").Value == cid);

            if (delProducers != null)
            {   
                delProducers.Remove();
                doc.Save(path2);
            }     
        }

        private void DeleteProducts(string cid)
        {
            XDocument doc = XDocument.Load(path3);
            XElement root = doc.Element("root");
            var products = root.Elements("product");
            var delProducts = products.Where(x => x.Attribute("cid").Value == cid);

            if (delProducts != null)
            {
                delProducts.Remove();
                doc.Save(path3);
            }
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            //DELETE CATEGORIES
            string cid = DeleteCategory();
            //

            if (cid == String.Empty)
                return;

            // DELETE PRODUCERS
            DeleteProducers(cid);
            //

            // DELETE PRODUCTS
            DeleteProducts(cid);
            //
         
            MessageBox.Show($"Категория <{CategoryName}> успешно удалена");
            this.DialogResult = true;
        }
    }
}
