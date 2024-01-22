using Bukma.Elements;
using Bukma.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukma.ViewModels.Windows
{
    public class ResultSavingWindowViewModel : BaseViewModel
    {
        public ResultSavingWindowViewModel(bool result, ResultSavingWindow window)
        {
            ResultText = result ? "Udało sie pomyślnie zapisać" : "Brakuje elementów wymaganych";
            Window = window;
        }

        #region Properties

        public ResultSavingWindow Window
        {
            get { return _Window; }
            set
            {
                _Window = value;
                OnPropertyChanged();
            }
        }
        private ResultSavingWindow _Window;


        public string ResultText
        {
            get { return _ResultText; }
            set
            {
                _ResultText = value;
                OnPropertyChanged();
            }
        }
        private string _ResultText;


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
                    Window.Close();
                });
            }
        }
        
        #endregion
    }
}
