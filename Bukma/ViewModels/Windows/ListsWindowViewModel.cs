using Autofac;
using Bukma.Elements;
using Bukma.Factories;
using Bukma.Filters;
using Bukma.Views.Windows;
using Data.Services;
using Models.Enums;
using Models.Models;
using Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukma.ViewModels.Windows
{
    public class ListsWindowViewModel:SavingViewModel<OrderArticle, V_OrderArticle, IOrderArticleService, OrderArticleFilter>, INameFiltrationViewModel
    {
        public ListsWindowViewModel(OrderViewModel parent, ListsWindow window, ArticlesWindowViewModel child)
        {
            IsLoading = true;
            Parent = parent;
            Child = child;
            Window = window;
            Filter = new OrderArticleFilter();
            Task.Run(() => LoadArticles());
            Task.Run(() => Load()) ;
        }

        #region Properties
        public ArticlesWindowViewModel Child { get; set; }
        public OrderViewModel Parent { get; set; }
        public ListsWindow Window { get; set; }

        public int? ArticleId
        {
            get { return EditItem != null ? EditItem.ArticleId : null; }
            set
            {
                EditItem.ArticleId = value;
                if(value != null)
                    using (var scope = App.Container.BeginLifetimeScope())
                    {
                        var articleService = scope.Resolve<IViewModelFactory>().Create<IArticleService>();
                        EditItem.Article = articleService.GetItem(value.Value);
                    }
                OnPropertyChanged();
            }
        }
        public List<V_Article> ArticleForSelection
        {
            get { return _ArticleForSelection; }
            set
            {
                _ArticleForSelection = value;
                OnPropertyChanged();
            }
        }
        private List<V_Article> _ArticleForSelection;

        #endregion
        #region Methods
        public void FiltrateName(string name = null)
        {
            if (name == null || name == "")
                Filter = new OrderArticleFilter();
            else
                Filter = new OrderArticleFilter(name);
            Load();
        }
        public override void FindItem(int Id)
        {
            base.FindItem(Id);
            OnPropertyChanged(nameof(ArticleId));
        }

        public async void LoadArticles()
        {
                await Task.Run(() =>
                {
                    using (var scope = App.Container.BeginLifetimeScope())
                    {
                        IsLoading = true;
                        var articleService = scope.Resolve<IViewModelFactory>().Create<IArticleService>();
                        ArticleForSelection = articleService.GetAllItems().OrderBy(x => x.Name).ToList();
                        IsLoading = false;
                    }
                });
        }

        public void MakeFiltration(OrderArticleFilter filter = null)
        {
            if (filter == null)
                Filter = new OrderArticleFilter();
            else
                Filter = filter;
            Load();
        }
        public void LoadParentOrderArticle()
        {
            Parent.LoadOrderArticles();
        }

        #endregion
        #region Commands
        public Command AddNewItemCommand
        {
            get
            {
                return new Command(() =>
                {
                    EditItem = new OrderArticle();
                    Task.Run(() => LoadArticles());
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
                        LoadParentOrderArticle();
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
