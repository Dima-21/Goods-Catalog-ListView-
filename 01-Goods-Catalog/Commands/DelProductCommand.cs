using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Goods_Catalog.ViewModels;
using _01_Goods_Catalog.DialogServise;

namespace _01_Goods_Catalog.Commands
{
    class DelProductCommand : MyCommand
    {
        DialogServises ds = new DialogServises();
        public DelProductCommand(ProductViewModels wm) : base(wm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            WM.DelProduct(ds.OpenDelProductWindow());
        }
    }
}
