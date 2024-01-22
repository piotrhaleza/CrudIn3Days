using Bukma.ViewModels;
using Bukma.ViewModels.Windows;
using Bukma.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukma.Factories
{
    public interface IViewModelFactory : IServicesFactory, IDisposable
    {
        MainWindowViewModel CreateMainWindowViewModel();
        OrderViewModel CreateOrderViewModel();
        ClientWindowViewModel CreateClientWindowViewModel(OrderViewModel parent, ClientWindow window, int? clientId = null);
        ListsWindowViewModel CreateListsWindowViewModel(OrderViewModel parent, ListsWindow window, ArticlesWindowViewModel child);
        ArticlesWindowViewModel CreateArticlesWindowViewModel(ListsWindow window);
        ResultSavingWindowViewModel CreateResultSavingWindowViewModel(bool result, ResultSavingWindow window);
        ClientFiltrationWindowViewModel CreateClientFiltrationWindowViewModel(ClientFiltrationWindow window, ClientWindowViewModel parent);
        NameFiltrationViewModel CreateNameFiltrationWindowViewModel(NameFiltrationWindow nameFiltrationWindow, INameFiltrationViewModel viewModel);
    }
}
