using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _01_Goods_Catalog.ViewModels;
using _01_Goods_Catalog.DialogServise;

namespace _01_Goods_Catalog.Commands
{
    class AddCategoryCommand : MyCommand
    {
        DialogServises ds = new DialogServises();
        public AddCategoryCommand(ProductViewModels wm) : base(wm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var c = ds.OpenAddCategoryWindow();
            if (c != null)
                WM.AddCategory(c);
        }
    }
}
