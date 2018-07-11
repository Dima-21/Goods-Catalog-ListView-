using _01_Goods_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _01_Goods_Catalog.ViewModels
{
    class ProductViewModels : INotifyPropertyChanged
    {

        private XDocument doc;
        private string path;
        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedContact");
            }
        }
        public ObservableCollection<Product> Products { get; set; }

        public ProductViewModels()
        {
            Products = new ObservableCollection<Product>();
            path = @"..\..\Data\Products.xml";
            doc = XDocument.Load(path);
            LoadData();
        }

        public void LoadData()
        {
            var res = doc.Element("root").Elements("product").ToList();
            foreach (var x in res)
            {
                Product p = new Product()
                {
                    Name = x.Attribute("name").Value,
                    Id = x.Attribute("id").Value,
                    Price = x.Attribute("price").Value,
                    Num = x.Attribute("num").Value,
                    Cid = x.Attribute("cid").Value,
                    Pid = x.Attribute("pid").Value,
                    Category = x.Attribute("category").Value,
                    Producer = x.Attribute("producer").Value
                };
                Products.Add(p);
            }
        }

        public void AddProduct(Product p)
        {
            AddProductWindow addwin = new AddProductWindow();

            if (addwin.ShowDialog() == true)
            {
                string id = doc.Element("root").Elements("product").Last().Attribute("id").Value;
                XElement newElem = new XElement("contact",
                    new XAttribute("id", id),
                new XAttribute("name", addwin.NameProduct),
                new XAttribute("price", addwin.price),
                new XAttribute("num", addwin.num),
                new XAttribute("cid", addwin.Cid),
                new XAttribute("pid", addwin.Pid),
                new XAttribute("producer", addwin.NameProducer),
                new XAttribute("category", addwin.NameCategory));
                doc.Element("root").Add(newElem);
                doc.Save(path);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
