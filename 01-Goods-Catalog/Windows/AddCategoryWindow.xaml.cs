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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        public AddCategoryWindow()
        {
            InitializeComponent();

        }

        private void addCategory(object sender, RoutedEventArgs e)
        {
            string name = category.Text;
            if (String.IsNullOrEmpty(name))
                MessageBox.Show("Вы не ввели название категории", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                this.DialogResult = true;
          
        }
    }
}
