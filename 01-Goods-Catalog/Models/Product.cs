using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _01_Goods_Catalog.Models
{
    class Product : INotifyPropertyChanged
    {
        private string name;
        private string id;
        private string price;
        private string num;
        private string pid;
        private string cid;
        private string producer;
        private string category;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Name");
            }
        }
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public string Num
        {
            get { return num; }
            set
            {
                num = value;
                OnPropertyChanged("Num");
            }
        }
        public string Pid
        {
            get { return pid; }
            set
            {
                pid = value;
                OnPropertyChanged("Pid");
            }
        }
        public string Cid
        {
            get { return cid; }
            set
            {
                cid = value;
                OnPropertyChanged("Cid");
            }
        }
        public string Producer
        {
            get { return producer; }
            set
            {
                producer = value;
                OnPropertyChanged("Producer");
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
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
