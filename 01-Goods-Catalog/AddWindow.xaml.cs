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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string name = category.Text;
            if (String.IsNullOrEmpty(name))
                MessageBox.Show("Вы не ввели название категории", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                string path = @"..\..\Data\Categories.xml";
                XDocument doc = XDocument.Load(path);
                var root = doc.Element("root");
                var categories = root.Elements("category");
                int k = categories.Count();
              
                XElement newElem = new XElement("category", 
                    new XAttribute("id", k),
                    new XAttribute("name", name));
                root.Add(newElem);
                doc.Save(path);
                MessageBox.Show("Категория успешно добавлена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
            }
        }
    }
}
