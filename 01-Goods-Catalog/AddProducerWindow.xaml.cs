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
    /// Interaction logic for AddProducerWindow.xaml
    /// </summary>
    public partial class AddProducerWindow : Window
    {
        public AddProducerWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string producer = pName.Text;
            if (String.IsNullOrEmpty(producer))
                MessageBox.Show("Вы не ввели название производителя", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                string path = @"..\..\Data\Producers.xml";
                XDocument doc = XDocument.Load(path);
                var root = doc.Element("root");
                var categories = root.Elements("producer");

                var k = listCategory.SelectedIndex;
                string cid = GetId(k);

                int newId = Int32.Parse(categories.Last().Attribute("id").Value) + 1;
                XElement newElem = new XElement("producer",
                    new XAttribute("id", newId),
                    new XAttribute("name", producer),
                    new XAttribute("cid", cid));
                root.Add(newElem);
                doc.Save(path);
                MessageBox.Show("Производитель успешно добавлен", "Сообщение", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
            }
        }
        private string GetId(int k)
        {
                string path = @"..\..\Data\Categories.xml";
                XDocument doc = XDocument.Load(path);
                var root = doc.Element("root");
                var categories = root.Elements("category");
                var category = categories.ToList()[k];
                return category.Attribute("id").Value;  
        }
    }
}
