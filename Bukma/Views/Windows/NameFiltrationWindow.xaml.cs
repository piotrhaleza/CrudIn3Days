using Autofac;
using Bukma.Factories;
using Bukma.ViewModels.Windows;
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
using System.Windows.Shapes;

namespace Bukma.Views.Windows
{
    /// <summary>
    /// Interaction logic for NameFiltrationWindow.xaml
    /// </summary>
    public partial class NameFiltrationWindow : Window
    {
        public NameFiltrationWindow(INameFiltrationViewModel viewModel)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Owner = Application.Current.MainWindow;

            using (var scope = App.Container.BeginLifetimeScope())
            {
                var viewModelFactory = scope.Resolve<IViewModelFactory>();
                DataContext = viewModelFactory.CreateNameFiltrationWindowViewModel(this, viewModel);
            }
        }
    }
}
