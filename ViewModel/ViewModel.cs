using SfDataGridDemo;
using Syncfusion.UI.Xaml.ScrollAxis;
//using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo
{
    public class ViewModel:INotifyPropertyChanged
    {      

        private ObservableCollection<OrderInfo> orderCollection;
        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get
            {
                return orderCollection;
            }
            set
            {
                orderCollection = value;
                RaisePropertyChanged("OrderInfoCollection");
            }
        }
     
        public ViewModel()
        {
            orderCollection = new ObservableCollection<OrderInfo>();
           
            OrderInfoCollection = GenerateOrders();           
        }

       
        public ObservableCollection<OrderInfo> GenerateOrders()
        {
            ObservableCollection<OrderInfo> orders = new ObservableCollection<OrderInfo>();
            //for (int i = 0; i < 2; i++)
            //{
                //orders.Add(new OrderInfo(1001, "Bulk", "Beverton", "ALFKI", "US",false));
                //orders.Add(new OrderInfo(1002, "Oliver", "Oregon", "ANATR", "UK",false));
                //orders.Add(new OrderInfo(1003, "Brendon", "Johanesberg", "ANTON", "NY", false));
                //orders.Add(new OrderInfo(1004, "John", "Chicago", "YHGTR", "UK", false));
                //orders.Add(new OrderInfo(1005, "Charles", "Spain", "BERGS", "UK", false));
                //orders.Add(new OrderInfo(1006, "Dintin", "Britain", "TGVFD", "US", false));
                //orders.Add(new OrderInfo(1007, "Friedo", "Britain", "YTREW", "US", false));
                //orders.Add(new OrderInfo(1008, "John", "Oregon", "MNBGY", "NY", false));
                //orders.Add(new OrderInfo(1009, "Sirert", "Bulk", "BGFDE", "US", false));
                //orders.Add(new OrderInfo(1010, "Rakesh", "hertion", "BOTTM", "NY", false));
          //  }
                          
            return orders;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

