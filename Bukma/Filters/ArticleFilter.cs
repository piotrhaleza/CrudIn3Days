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
    public class ArticleFilter : IFilter<V_Article>, INotifyPropertyChanged
    { 
        public ArticleFilter(string nameFiltred = null)
        {
            NameFiltred = nameFiltred;
            IsSetUp = NameFiltred != null;
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
        public List<V_Article> GetFiltredList(List<V_Article> values)
        {
            return values.Where(x => NameFiltred == null || x.Name.StartsWith(NameFiltred)).ToList();
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


