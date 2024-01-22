using Models.Attributes;
using Models.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Order :BaseModel<int>
    {
        public DateTime Date { get; set; } = DateTime.Now;
        [NotMapped]
        public List<V_OrderArticle> OrderArticles
        {
            get { return _OrderArticles; }
            set
            {
                _OrderArticles = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NettoValue));
                OnPropertyChanged(nameof(BruttoValue));
                OnPropertyChanged(nameof(IsAnyOrderArticles));
            }
        }
        private List<V_OrderArticle> _OrderArticles = new List<V_OrderArticle>();
        [NotMapped]
        public List<V_OrderArticle> Added_OrderArticles { get; set; } = new List<V_OrderArticle>();
        [NotMapped]
        public List<V_OrderArticle> Deleted_OrderArticles { get; set; } = new List<V_OrderArticle>();

        [IsRequiredInt]
        public int? ClientId
        {
            get { return _ClientId; }
            set
            {
                _ClientId = value;
                OnPropertyChanged();
            }
        }
        private int? _ClientId;

        [NotMapped]
        public int NettoValue => OrderArticles.Sum(x => x.ValueNetto);
        [NotMapped]
        public int BruttoValue => OrderArticles.Sum(x => x.ValueBrutto);

        [NotMapped]
        [IsRequiredBoolAttribute]
        public bool IsAnyOrderArticles => OrderArticles.Count() != 0;
    }
}
