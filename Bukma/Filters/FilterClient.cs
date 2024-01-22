using Models.Models;
using Models.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bukma.Filters
{
    public class FilterClient : IFilter<V_Client>, INotifyPropertyChanged
    {
        public FilterClient(string nameFiltred = null, string surnameFiltred =null)
        {
            NameFiltred = nameFiltred;
            SurnameFiltred = surnameFiltred;
            IsSetUp = NameFiltred != null || SurnameFiltred != null;
        }
        public bool IsSetUp
        {
            get { return _IsSetUp; }
            set
            {
                _IsSetUp = value;
                OnPropertyChanged();
            }
        }
        private bool _IsSetUp;

        private string NameFiltred { get; set; }
        private string SurnameFiltred { get; set; }
        public List<V_Client> GetFiltredList(List<V_Client> values)
        {
            return values.Where(x => (NameFiltred == null || x.Name.StartsWith(NameFiltred)) && (SurnameFiltred == null || x.Surname.StartsWith(SurnameFiltred))).ToList();
        }
        #region PropertyChanged
        /// <summary>
        /// Zdarzenie obsługujące zmianę wartości właściwości (implementowane przez INotifyPropertyChanged).
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Podnosi zdarzenie PropertyChanged dla konkretnej wałaściwości.
        /// </summary>
        /// <param name="name">Nazwa właściwości.</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
