using Autofac;
using Bukma.Factories;
using Bukma.ViewModels;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bukma.Views
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();
            
            using(var scope = App.Container.BeginLifetimeScope())
            {
                var viewModelFactory = scope.Resolve<IViewModelFactory>();
                DataContext =  viewModelFactory.CreateOrderViewModel();
            }
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;

            if (item != null)
                (DataContext as OrderViewModel).FindItem((item.Content as BaseModel<int>).Id);
        }
    }
}
