using Autofac;
using Bukma.Elements;
using Bukma.Factories;
using Bukma.Filters;
using Data.Services;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukma.ViewModels
{
    public class SavingViewModel<Item,V_Item, IService, IFiltr> :BaseViewModel
        where Item : BaseModel<int>
        where IService : ISaveService<Item, V_Item>
        where IFiltr   : class,IFilter<V_Item>
    {
        public SavingViewModel()
        {

        }

        #region Properties
        public CreatingType CreatingType
        {
            get { return _CreatingType; }
            set
            {
                _CreatingType = value;
                OnPropertyChanged();
            }
        }
        private CreatingType _CreatingType = CreatingType.None;

        public bool IsLoading
        {
            get { return _IsLoading; }
            set
            {
                _IsLoading = value;
                OnPropertyChanged();
            }
        }
        private bool _IsLoading;

        public Item EditItem
        {
            get { return _EditItem; }
            set
            {
                _EditItem = value;
                OnPropertyChanged();
            }
        }
        private Item _EditItem;
        public List<V_Item> Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
                OnPropertyChanged();
            }
        }
        private List<V_Item> _Items;

        public IFiltr Filter
        {
            get { return _Filter; }
            set
            {
                _Filter = value;
                OnPropertyChanged();
            }
        }
        private IFiltr _Filter;
        #endregion
        #region Methods
        public virtual void FindItem(int Id)
        {
            if (CreatingType == CreatingType.None || CreatingType == CreatingType.ViewItem)
            {
                using (var scope = App.Container.BeginLifetimeScope())
                {
                    var service = scope.Resolve<IViewModelFactory>().Create<IService>();
                    EditItem = service.GetItem(Id);
                }
                CreatingType = CreatingType.ViewItem;
            }
        }

        public async Task<bool> Save()
        {
            bool result;

            using (var scope = App.Container.BeginLifetimeScope())
            {
                var viewModelFactory = scope.Resolve<IViewModelFactory>();
                var service = viewModelFactory.Create<IService>();
                result = await service.Save(EditItem);
            }


            return result;
        }
        public void Load()
        {
            using (var scope = App.Container.BeginLifetimeScope())
            {
                var articleService = scope.Resolve<IViewModelFactory>().Create<IService>();
                Items = Filter.GetFiltredList(articleService.GetAllItems());
                IsLoading = false;
            }
        }
        #endregion
        #region Commands
        public Command CancelCommand
        {
            get
            {
                return new Command(() =>
                {
                    EditItem = null;
                    CreatingType = CreatingType.None;
                });
            }
        }
        public Command EditCommand
        {
            get
            {
                return new Command(() =>
                {
                    CreatingType = CreatingType.EditItem;
                });
            }
        }
        #endregion
    }
}
