using Autofac;
using Bukma.Elements;
using Bukma.Factories;
using Bukma.Filters;
using Bukma.Views.Windows;
using Data;
using Data.Services;
using Models.Enums;
using Models.Models;
using Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bukma.ViewModels.Windows
{
    public class ClientWindowViewModel : SavingViewModel<Client, V_Client, IClientService, FilterClient>
    {
        public ClientWindowViewModel(OrderViewModel parent, ClientWindow window, int? clientId = null)
        {
            IsLoading = true;
            Parent = parent;
            Window = window;
            Filter = new FilterClient();
            Task.Run(() => Load());
            if (clientId != null)
                FindItem(clientId.Value);
        }

        #region Properties
        public OrderViewModel Parent { get; set; }
        public ClientWindow Window { get; set; }
        #endregion
        #region Methods

        public void MakeFiltration(FilterClient filter = null)
        {
            if (filter == null)
                Filter = new FilterClient();
            else
                Filter = filter;
            Load();
        }
        #endregion
        #region Commands
        public Command AddNewItemCommand
        {
            get
            {
                return new Command(() =>
                {
                    EditItem = new Client();
                    CreatingType = CreatingType.CreateNewItem;
                });
            }
        }
        public Command FilterCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Filter.IsSetUp)
                        MakeFiltration();
                    else
                    {
                        IsLoading = true;
                        using (var scope = App.Container.BeginLifetimeScope())
                        {
                            var windowFactory = scope.Resolve<IWindowFactory>();
                            var window = windowFactory.CreateClientFiltrationWindow(this);
                            window.ShowDialog();
                        }
                    }
                });
            }
        }
        public Command SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsLoading = true;
                    var result = await Task.Run(() => Save());

                    using (var scope = App.Container.BeginLifetimeScope())
                    {
                        var windowFactory = scope.Resolve<IWindowFactory>();
                        var window = windowFactory.CreateResultSavingWindow(result);
                        window.ShowDialog();
                    }
                    if (result)
                    {
                        await Task.Run(() => Load());
                        Parent.LoadClients();
                        CreatingType = CreatingType.ViewItem;
                    }
                    else
                        IsLoading = false;

                });
            }
        }
        public Command ChooseCommand
        {
            get
            {
                return new Command(() =>
                {
                    Parent.ChooseClient(EditItem.Id);
                    Window.Close();

                });
            }
        }
        #endregion
    }
}
