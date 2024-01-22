using Bukma.Elements;
using Bukma.Filters;
using Bukma.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukma.ViewModels.Windows
{
    public class NameFiltrationViewModel : BaseViewModel
    {
        public NameFiltrationViewModel(NameFiltrationWindow nameFiltrationWindow, INameFiltrationViewModel viewModel)
        {
            Parent = viewModel;
            Window = nameFiltrationWindow;
        }

        #region Properties
        public INameFiltrationViewModel Parent { get; set; }
        public NameFiltrationWindow Window { get; set; }
        public string FiltredName { get; set; }
        #endregion
        #region Methods

        #endregion
        #region Commands
        public Command ExitCommand
        {
            get  
            {
                return new Command(() =>
                {
                    Parent.FiltrateName(FiltredName);
                    Window.Close();
                });
            }
        }

        #endregion
    }
}
