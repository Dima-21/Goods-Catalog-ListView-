using _01_Goods_Catalog.Commands;
using _01_Goods_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace _01_Goods_Catalog.ViewModels
{
    class ProductViewModels : INotifyPropertyChanged
    {

        private XDocument doc;
        private const string path1 = @"..\..\Data\Products.xml";
        private const string path2 = @"..\..\Data\Producers.xml";
        private const string path3 = @"..\..\Data\Categories.xml";
        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private Producer selectedProducer;
        public Producer SelectedProducer
        {
            get { return selectedProducer; }
            set
            {
                selectedProducer = value;
                OnPropertyChanged("SelectedProducer");
            }
        }

        private Producer selectedCategory;
        public Producer SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        private Filter filterProp;
        public Filter FilterProp
        {
            get
            {
                Filter f = new Filter()
                { Category = SelectedCategory.Name, Producer = SelectedProducer.Name };
                return f;
            }
            set
            {
                filterProp = value;
                OnPropertyChanged("FilterProp");
            }
        }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ProductViewModels()
        {
            Products = new ObservableCollection<Product>();
            Categories = new ObservableCollection<Category>();
            doc = XDocument.Load(path1);
            LoadData();
        }

        public void Select(Filter f)
        {
            var res = Products.Where(x=>x.Category == FilterProp.Category && x.Producer == FilterProp.Producer);
            Products.Clear();
            foreach (var prod in res)
            {
                Products.Add(prod);
            }
        }
        public void LoadData()
        {
            doc = XDocument.Load(path1);
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

            doc = XDocument.Load(path3);
            var res1 = doc.Element("root").Elements("category").ToList();
            foreach (var x in res1)
            {
                Category c = new Category()
                {
                    Name = x.Attribute("name").Value,
                    Id = x.Attribute("id").Value
                };

                    Categories.Add(c);
            }
        }


        public void AddProduct(Product p)
        {
            AddProductWindow addwin = new AddProductWindow();

            if (addwin.ShowDialog() == true)
            {
                string id = doc.Element("root").Elements("product").Last().Attribute("id").Value;
                //XElement newElem = new XElement("contact",
                //    new XAttribute("id", id),
                //new XAttribute("name", addwin.NameProduct),
                //new XAttribute("price", addwin.price),
                //new XAttribute("num", addwin.num),
                //new XAttribute("cid", addwin.Cid),
                //new XAttribute("pid", addwin.Pid),
                //new XAttribute("producer", addwin.NameProducer),
                //new XAttribute("category", addwin.NameCategory));
                //doc.Element("root").Add(newElem);
                doc.Save(path1);
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
