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
        const string path1 = @"..\..\Data\Categories.xml";
        const string path2 = @"..\..\Data\Producers.xml";
        const string path3 = @"..\..\Data\Products.xml";

        public String NameProducer { get; set; }
        public String NameCategory { get; set; }
        public String Pid { get; set; }
        public String Cid { get; set; }
        public int SelectIndex { get; set; }

        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void SetValueProducer()
        {
            XDocument doc = XDocument.Load(path2);
            XElement root = doc.Element("root");
            var producers = root.Elements("producer");
            Pid = producers.ToList()[SelectIndex].Attribute("id").Value;
            Cid = producers.ToList()[SelectIndex].Attribute("cid").Value;
            NameProducer = producers.ToList()[SelectIndex].Attribute("name").Value;
        }

        private void SetValueCategory()
        {
            XDocument doc = XDocument.Load(path1);
            XElement root = doc.Element("root");
            var categories = root.Elements("category");
            NameCategory = categories.FirstOrDefault(x => x.Attribute("id").Value == Cid).Attribute("name").Value;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            XDocument doc = XDocument.Load(path3);
            XElement root = doc.Element("root");
            var products = root.Elements("product");
            int lastId = Int32.Parse(products.Last().Attribute("id").Value) + 1;

           
            if (listProducer.SelectedIndex != 0 && name.Text != String.Empty &&
                price.Text != String.Empty && num.Text != String.Empty)
            {
                SetValueProducer();
                SetValueCategory();
                XElement newProduct = new XElement("product",
                    new XAttribute("id", lastId),
                      new XAttribute("name", name.Text),
                       new XAttribute("price", price.Text),
                        new XAttribute("num", num.Text),
                        new XAttribute("pid", Pid),
                        new XAttribute("cid", Cid),
                        new XAttribute("producer", NameProducer),
                        new XAttribute("category", NameCategory));
                root.Add(newProduct);
                doc.Save(path3);
                MessageBox.Show("Товар успешно добавлен", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void listProducer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectIndex = listProducer.SelectedIndex;
        }
    }
}
