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
        public DeleteCategoryWindow()
        {
            InitializeComponent();
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            int k = listCategories.SelectedIndex;
            string path = @"..\..\Data\Categories.xml";
            XmlDataProvider xdp = new XmlDataProvider();
            XDocument doc = XDocument.Load(path);
            XElement root = doc.Element("root");
            var categories = root.Elements("category");
            //var delcategory = categories.Where(x => x.Attribute("id").Value == k.ToString()).FirstOrDefault();
            var delcategory = categories.ToList()[k];
            string name = delcategory.Attribute("name").Value;
            //DELETE_Producer
            string idCategory = delcategory.Attribute("id").Value;
            string path2 = @"..\..\Data\Producers.xml";
            XDocument doc2 = XDocument.Load(path2);
            XElement root2 = doc2.Element("root");
            var categories2 = root2.Elements("producer");
            var delProducers = categories2.Where(x => x.Attribute("cid").Value == idCategory);
             //
     
            foreach (var producer in categories2)
            {
                delProducers.Remove();
            }

            if (categories != null && k > 0)
                delcategory.Remove();

            doc.Save(path);
            doc2.Save(path2);
            MessageBox.Show($"Категория <{name}> успешно удалена");
            this.DialogResult = true;
        }
    }
}
