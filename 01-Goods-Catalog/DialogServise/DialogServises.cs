using _01_Goods_Catalog.Models;
using _01_Goods_Catalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Goods_Catalog.DialogServise
{
    class DialogServises
    {
        public Category OpenAddCategoryWindow()
        {
            AddCategoryWindow win = new AddCategoryWindow();
            if (win.ShowDialog() == true)
            {
                Category c = new Category()
                {
                    Name = win.category.Text,
                    Id = "0"
                };
                return c;
            }
            return null;
        }

        public Product OpenAddProductWindow()
        {
            AddProductWindow win = new AddProductWindow();
            if (win.ShowDialog() == true)
            {
                Product p = new Product()
                {
                    Name = win.name.Text,
                    Price = win.price.Text,
                    Num = win.num.Text,
                    Category = (win.listCategory.SelectedItem as Category).Name,
                    Cid = (win.listCategory.SelectedItem as Category).Id,
                    Producer = (win.listProducer.SelectedItem as Producer).Name,
                    Pid = (win.listProducer.SelectedItem as Producer).Id
                };
                return p;
            }
            return null;
        }

        public Product OpenDelProductWindow()
        {
            DeleteProductWindow win = new DeleteProductWindow();
            if (win.ShowDialog() == true)
            {
                Product p = win.listProduct.SelectedItem as Product;
                return p;
            }
            return null;
        }
    }
}


