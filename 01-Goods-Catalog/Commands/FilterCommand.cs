using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Goods_Catalog.ViewModels;

namespace _01_Goods_Catalog.Commands
{
    class FilterCommand : MyCommand
    {
        public FilterCommand(ProductViewModels wm) : base(wm)
        {}

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            WM.Select((Filter)parameter);
        }
    }
}
