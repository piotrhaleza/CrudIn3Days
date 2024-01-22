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
    public class ViewModelFactory : ServicesFactory, IViewModelFactory
    {
        public ViewModelFactory(ILifetimeScope scope) : base(scope)
        {
        }

        public ArticlesWindowViewModel CreateArticlesWindowViewModel( ListsWindow window)
        {
            return _scope.Resolve<ArticlesWindowViewModel>(
                new NamedParameter(nameof(window), window));
        }

        public ClientFiltrationWindowViewModel CreateClientFiltrationWindowViewModel(ClientFiltrationWindow window, ClientWindowViewModel parent)
        {
            return _scope.Resolve<ClientFiltrationWindowViewModel>(
                new NamedParameter(nameof(window), window),
                new NamedParameter(nameof(parent), parent));
        }

        public ClientWindowViewModel CreateClientWindowViewModel(OrderViewModel parent, ClientWindow window, int? clientId = null)
        {
            return _scope.Resolve <ClientWindowViewModel>(
                new NamedParameter(nameof(parent), parent),
                new NamedParameter(nameof(window), window),
                new NamedParameter(nameof(clientId), clientId)); 
        }

        public ClientWindowViewModel CreateClientWindowViewModel(OrderViewModel parent, ClientWindow window)
        {
            throw new NotImplementedException();
        }

        public ListsWindowViewModel CreateListsWindowViewModel(OrderViewModel parent, ListsWindow window, ArticlesWindowViewModel child)
        {
            return _scope.Resolve<ListsWindowViewModel>(
                new NamedParameter(nameof(parent), parent),
                new NamedParameter(nameof(window), window),
                new NamedParameter(nameof(child), child));
        }

        public MainWindowViewModel CreateMainWindowViewModel()
        {
            return _scope.Resolve<MainWindowViewModel>();
        }

        public NameFiltrationViewModel CreateNameFiltrationWindowViewModel(NameFiltrationWindow nameFiltrationWindow, INameFiltrationViewModel viewModel)
        {
            return _scope.Resolve<NameFiltrationViewModel>(
              new NamedParameter(nameof(nameFiltrationWindow), nameFiltrationWindow),
              new NamedParameter(nameof(viewModel), viewModel));
        }

        public OrderViewModel CreateOrderViewModel()
        {
            return _scope.Resolve<OrderViewModel>();
        }

        public ResultSavingWindowViewModel CreateResultSavingWindowViewModel(bool result, ResultSavingWindow window)
        {
            return _scope.Resolve<ResultSavingWindowViewModel>(
                new NamedParameter(nameof(result), result),
                new NamedParameter(nameof(window), window));
        }

        public void Dispose()
        {

        }
    }
}