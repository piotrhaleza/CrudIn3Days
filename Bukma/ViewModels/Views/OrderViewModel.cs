using Autofac;
using Bukma.Elements;
using Bukma.Factories;
using Bukma.Filters;
using Bukma.Views.Windows;
using Data.Services;
using Models.Models;
using Models.Enums;
using Models.Prototypes;
using Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bukma.ViewModels
{
    public class OrderViewModel : SavingViewModel<Order, V_Order, IOrderService, OrderFilter>, INameFiltrationViewModel
    {
        public OrderViewModel()
        {
            Filter = new OrderFilter();
            EditItem = new Order();
            Load();
            LoadClients();
            LoadOrderArticles();
        }

        #region Properties

        public int? ClientId
        {
            get { return EditItem != null? EditItem.ClientId : null; }
            set
            {
                EditItem.ClientId = value;
                OnPropertyChanged();
            }
        }
        public int? OrderArticleId
        {
            get { return _OrderArticleId; }
            set
            {
                _OrderArticleId = value;
                OnPropertyChanged();
            }
        }
        private int? _OrderArticleId;

        public List<V_Client> ClientsForSelection
        {
            get { return _ClientsForSelection; }
            set
            {
                _ClientsForSelection = value;
                OnPropertyChanged();
            }
        }
        private List<V_Client> _ClientsForSelection;

        public List<V_OrderArticle> OrderArticleForSelection
        {
            get { return _OrderArticleForSelection; }
            set
            {
                _OrderArticleForSelection = value;
                OnPropertyChanged();
            }
        }
        private List<V_OrderArticle> _OrderArticleForSelection;

        #endregion
        #region Methods
        public void FiltrateName(string name = null)
        {
            if (name == null || name == "")
                Filter = new OrderFilter();
            else
                Filter = new OrderFilter(name);
            Load();
        }
        public override void FindItem(int Id)
        {
            if (CreatingType == CreatingType.None || CreatingType == CreatingType.ViewItem)
            {
                using (var scope = App.Container.BeginLifetimeScope())
                {
                    var service = scope.Resolve<IViewModelFactory>().Create<IOrderService>();
                    EditItem = service.GetItem(Id);
                    LoadOrderArticles();
                    foreach (var item in EditItem.OrderArticles)
                        OrderArticleForSelection.Remove(OrderArticleForSelection.FirstOrDefault(x => x.Id == item.Id));
                    ClientId = EditItem.ClientId;
                }
                CreatingType = CreatingType.ViewItem;
            }
        }
        public async void LoadClients()
        {
            await Task.Run(() =>
            {
                using (var scope = App.Container.BeginLifetimeScope())
                {
                    IsLoading = true;
                    var clientService = scope.Resolve<IViewModelFactory>().Create<IClientService>();
                    ClientsForSelection = clientService.GetAllItems().OrderBy(x => x.Name).ToList();
                    IsLoading = false;
                }
            });
        }
        public async void LoadOrderArticles()
        {
            await Task.Run(() =>
            {
                using (var scope = App.Container.BeginLifetimeScope())
                {
                    IsLoading = true;
                    var orderArticleService = scope.Resolve<IViewModelFactory>().Create<IOrderArticleService>();
                    var allItems = orderArticleService.GetAllItems().OrderBy(x => x.Name).ToList();
                    List<V_OrderArticle> noChosenItems = allItems.ToList();

                    foreach (var newitem in allItems)
                        foreach (var olditem in EditItem.OrderArticles)
                            if (olditem.Id == newitem.Id)
                            {
                                new V_OrderArticleCopier().LowCopy(newitem, olditem );
                                noChosenItems.Remove(newitem);
                            }

                    EditItem.OrderArticles = EditItem.OrderArticles.ToList();
                    OrderArticleForSelection = noChosenItems;
                    IsLoading = false;
                }
            });
        }
        public void ChooseClient(int ClientId)
        {
            this.ClientId = ClientId;
        }


        #endregion
        #region Commands
        public Command AddOrderArticle
        {
            get
            {
                return new Command(() =>
                {
                    if (OrderArticleId != null)
                    {
                        EditItem.OrderArticles.Add(OrderArticleForSelection.FirstOrDefault(x => x.Id == OrderArticleId));
                        EditItem.OrderArticles = EditItem.OrderArticles.ToList();

                        EditItem.Added_OrderArticles.Add(OrderArticleForSelection.FirstOrDefault(x => x.Id == OrderArticleId));
                        EditItem.Deleted_OrderArticles.Remove(OrderArticleForSelection.FirstOrDefault(x => x.Id == OrderArticleId));


                        OrderArticleForSelection.Remove(OrderArticleForSelection.FirstOrDefault(x => x.Id == OrderArticleId));
                        OrderArticleForSelection = OrderArticleForSelection.ToList();
                        OrderArticleId = null;
                    }
                });
            }
        }
        public Command DeleteOrderArticle
        {
            get
            {
                return new Command(e =>
                {
                    var deleteItem = (V_OrderArticle)e;

                    try
                    {
                        EditItem.Added_OrderArticles.Remove(EditItem.OrderArticles.FirstOrDefault(x => x.Id == deleteItem.Id));
                        EditItem.Deleted_OrderArticles.Add(EditItem.OrderArticles.FirstOrDefault(x => x.Id == deleteItem.Id));

                        EditItem.OrderArticles.Remove(EditItem.OrderArticles.FirstOrDefault(x => x.Id == deleteItem.Id));
                        EditItem.OrderArticles = EditItem.OrderArticles.ToList();

                        OrderArticleForSelection.Add(deleteItem);
                        OrderArticleForSelection = OrderArticleForSelection.ToList();
                        OrderArticleId = null;
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }
        public Command AddNewItemCommand
        {
            get
            {
                return new Command(() =>
                {
                    EditItem = new Order();
                    LoadClients();
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
                        FiltrateName();
                    else
                    {
                        IsLoading = true;
                        using (var scope = App.Container.BeginLifetimeScope())
                        {
                            var windowFactory = scope.Resolve<IWindowFactory>();
                            var window = windowFactory.CreateNameFiltrationWindow(this);
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
                        CreatingType = CreatingType.ViewItem;
                    }
                    else
                        IsLoading = false;

                });
            }
        }
        public Command GoToClientWindowCommand
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        using (var scope = App.Container.BeginLifetimeScope())
                        {
                          
                            var factory = scope.Resolve<IWindowFactory>();
                            var window = factory.CreateClientWindow(this,ClientId);
                            ClientId = null;
                            window.Show();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }
        public Command GoToListWindowCommand
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        using (var scope = App.Container.BeginLifetimeScope())
                        {
                            var factory = scope.Resolve<IWindowFactory>();
                            var window = factory.CreateListsWindow(this);
                            window.Show();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }
        #endregion
    }
}
