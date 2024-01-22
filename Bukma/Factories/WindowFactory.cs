using Autofac;
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
    public class WindowFactory : ServicesFactory, IWindowFactory
    {
        public WindowFactory(ILifetimeScope scope) : base(scope)
        {
        }

        public ClientFiltrationWindow CreateClientFiltrationWindow(ClientWindowViewModel parent)
        {
            return _scope.Resolve<ClientFiltrationWindow>(
                  new NamedParameter(nameof(parent), parent));
        }

        public ClientWindow CreateClientWindow(OrderViewModel parent, int? clientId = null)
        {
            return _scope.Resolve<ClientWindow>(
                new NamedParameter(nameof(parent), parent),
                new NamedParameter(nameof(clientId), clientId));
        }

        public ListsWindow CreateListsWindow(OrderViewModel parent)
        {
            return _scope.Resolve<ListsWindow>(new NamedParameter(nameof(parent), parent));
        }

        public NameFiltrationWindow CreateNameFiltrationWindow(INameFiltrationViewModel viewModel)
        {
            return _scope.Resolve<NameFiltrationWindow>(new NamedParameter(nameof(viewModel), viewModel));
        }

        public ResultSavingWindow CreateResultSavingWindow(bool result)
        {
            return _scope.Resolve<ResultSavingWindow>(new NamedParameter(nameof(result), result));
        }

        public void Dispose()
        {

        }
    }
}
