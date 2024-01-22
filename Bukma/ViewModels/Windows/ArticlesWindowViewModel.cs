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
    public class ArticlesWindowViewModel : SavingViewModel<Article,V_Article,IArticleService, ArticleFilter>, INameFiltrationViewModel
    {
        public ArticlesWindowViewModel(ListsWindow window)
        {
            IsLoading = true;
            Window = window;
            Filter = new ArticleFilter();
            Task.Run(() => Load());
        }

        #region Properties
        public ListsWindowViewModel Parent { get; set; }
        public ListsWindow Window { get; set; }

        #endregion
        #region Methods
        public void FiltrateName(string name = null)
        {
            if (name == null || name == "")
                Filter = new ArticleFilter();
            else
                Filter = new ArticleFilter(name);
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
                    EditItem = new Article();
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
                        Parent.LoadParentOrderArticle();
                        CreatingType = CreatingType.ViewItem;
                    }
                    else
                        IsLoading = false;

                    Parent.LoadArticles();

                });
            }
        }
        #endregion
    }
}
