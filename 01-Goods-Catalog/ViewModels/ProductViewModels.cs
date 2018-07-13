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

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        private Filter filterParameter;
        public Filter FilterParameter
        {
            get
            {
                filterParameter.Category = SelectedCategory.Name;
                filterParameter.Producer = SelectedProducer.Name;
                return filterParameter;
            }
            set
            {          
                filterParameter = value;
            }
        }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Producer> Producers { get; set; }

        private AddCategoryCommand addCategory;
        public AddCategoryCommand AddCategory_
        {
            get
            {
                if (addCategory == null)
                    addCategory = new AddCategoryCommand(this);
                return addCategory;
            }
        }
        private FilterCommand filter;
        public FilterCommand Filter
        {
            get
            {
                if (filter == null)
                    filter = new FilterCommand(this);
                return filter;
            }
            set
            {
                filter = value;
                OnPropertyChanged("Filter");
            }
        }

        private AddProductCommand addProduct;
        public AddProductCommand AddProduct_
        {
            get
            {
                if (addProduct == null)
                    addProduct = new AddProductCommand(this);
                return addProduct;
            }
            set
            {
                addProduct = value;
                OnPropertyChanged("AddProduct_");
            }
        }
        private DelProductCommand delProduct;
        public DelProductCommand DelProduct_
        {
            get
            {
                if (delProduct == null)
                    delProduct = new DelProductCommand(this);
                return delProduct;
            }
            set
            {
                delProduct = value;
                OnPropertyChanged("DelProduct_");
            }
        }


        public ProductViewModels()
        {
            Products = new ObservableCollection<Product>();
            Categories = new ObservableCollection<Category>();
            Producers = new ObservableCollection<Producer>();
            doc = XDocument.Load(path1);     
            LoadData();
            SelectedCategory = Categories.First();
            SelectedProducer = Producers.First();
        }

        public void Select(Filter f)
        {
            List<Product> res;
            if (f.Category == "Все категории" && f.Producer == "Все производители")
            {
                LoadData();
                return;
            }
            if (f.Category == "Все категории" && f.Producer != "Все производители")
                res = Products.Where(x => x.Producer == FilterParameter.Producer).ToList();
            else
                res = Products.Where(x => x.Category == FilterParameter.Category).ToList();
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

            doc = XDocument.Load(path2);
            var res1 = doc.Element("root").Elements("producer").ToList();
            foreach (var x in res1)
            {
                Producer p = new Producer()
                {
                    Name = x.Attribute("name").Value,
                    Id = x.Attribute("id").Value,
                    Cid = x.Attribute("cid").Value
                };
                Producers.Add(p);
            }

            doc = XDocument.Load(path3);
            var res2 = doc.Element("root").Elements("category").ToList();
            foreach (var x in res2)
            {
                Category c = new Category()
                {
                    Name = x.Attribute("name").Value,
                    Id = x.Attribute("id").Value
                };
                Categories.Add(c);
            }
        }
        public void DelCategory(Category c)
        {
            if (c == null)
                return;
            c.Id = (Int32.Parse(Categories.Last().Id) + 1).ToString();
            Categories.Add(c);
            selectedCategory = c;
            doc = XDocument.Load(path3);
            XElement p = new XElement("category",
                new XAttribute("id", c.Id),
                new XAttribute("name", c.Name));
            doc.Element("root").Add(p);
            doc.Save(path3);
        }
        public void AddCategory(Category c)
        {
            if (c == null)
                return;
            c.Id = (Int32.Parse(Categories.Last().Id) + 1).ToString();
            Categories.Add(c);
            selectedCategory = c;
            doc = XDocument.Load(path3);
            XElement p = new XElement("category",
                new XAttribute("id", c.Id),
                new XAttribute("name", c.Name));
            doc.Element("root").Add(p);
            doc.Save(path3);
        }
        public void AddProduct(Product p)
        {
            
            if (p == null)
                return;
            p.Id = (Int32.Parse(Products.Last().Id) + 1).ToString();
            Products.Add(p);
            selectedProduct = p;
            doc = XDocument.Load(path1);
            XElement product = new XElement("product",
                    new XAttribute("id", p.Id),
                      new XAttribute("name", p.Name),
                       new XAttribute("price", p.Price),
                        new XAttribute("num", p.Num),
                        new XAttribute("pid", p.Pid),
                        new XAttribute("cid", p.Cid),
                        new XAttribute("producer", p.Producer),
                        new XAttribute("category", p.Category));
            doc.Element("root").Add(product);
            doc.Save(path1);
        }
        public void DelProduct(Product p)
        {
            if (p == null)
                return;
            var tmp = Products.FirstOrDefault(x => x.Id == p.Id);
            Products.Remove(tmp);
            selectedProduct = Products.First();
            doc = XDocument.Load(path1);           
            doc.Element("root").Elements("product").Where(x=>x.Attribute("id").Value==p.Id).Remove();         
            doc.Save(path1);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
