using _01_Goods_Catalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _01_Goods_Catalog.Commands
{
    abstract class MyCommand : ICommand
    {
        protected ProductViewModels WM;
        protected MyCommand(ProductViewModels wm)
        {
            WM = wm;
        }
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
