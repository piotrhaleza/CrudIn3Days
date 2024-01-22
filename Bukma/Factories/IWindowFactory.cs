using Bukma.ViewModels;
using Bukma.ViewModels.Windows;
using Bukma.Views.Windows;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukma.Factories
{
    public interface IWindowFactory : IServicesFactory, IDisposable
    {
        ClientWindow CreateClientWindow(OrderViewModel parent, int? clientId = null);
        ResultSavingWindow CreateResultSavingWindow(bool result);
        ClientFiltrationWindow CreateClientFiltrationWindow(ClientWindowViewModel parent);
        ListsWindow CreateListsWindow(OrderViewModel parent);
        NameFiltrationWindow CreateNameFiltrationWindow(INameFiltrationViewModel viewModel);
    }
}
