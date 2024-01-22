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
    public class ClientFiltrationWindowViewModel : BaseViewModel
    {
        public ClientFiltrationWindowViewModel(ClientFiltrationWindow window, ClientWindowViewModel parent)
        {
            Parent = parent;
            Window = window;
        }

        #region Properties
        public ClientWindowViewModel Parent { get; set; }
        public ClientFiltrationWindow Window { get;set; }
        public string FiltredName { get; set; }
        public string FiltredSurname { get; set; }
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
                    Parent.MakeFiltration(new FilterClient(FiltredName, FiltredSurname));
                    Window.Close();
                });
            }
        }

        #endregion
    }
}
