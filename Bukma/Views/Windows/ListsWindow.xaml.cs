using Autofac;
using Bukma.Factories;
using Bukma.ViewModels;
using Bukma.ViewModels.Windows;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bukma.Views.Windows
{
    /// <summary>
    /// Interaction logic for ListsWindow.xaml
    /// </summary>
    public partial class ListsWindow : Window
    {

        public ListsWindow(OrderViewModel parent)
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Owner = Application.Current.MainWindow;
            using (var scope = App.Container.BeginLifetimeScope())
            {
                var viewModelFactory = scope.Resolve<IViewModelFactory>();
                var articlesViewModel = viewModelFactory.CreateArticlesWindowViewModel(this);
                DataContext = viewModelFactory.CreateListsWindowViewModel(parent, this, articlesViewModel);
                articlesViewModel.Parent = DataContext as ListsWindowViewModel;
            }
        }
        private void ListViewItem_PreviewMouseLeftButtonDownArticles(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;

            if (item != null)
                (DataContext as ListsWindowViewModel).Child.FindItem((item.Content as BaseModel<int>).Id);
        }
        private void ListViewItem_PreviewMouseLeftButtonDownOrderArticles(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;

            if (item != null)
                (DataContext as ListsWindowViewModel).FindItem((item.Content as BaseModel<int>).Id);
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
