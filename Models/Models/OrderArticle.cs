using Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class OrderArticle:BaseModel<int>
    {
        [IsRequiredStringAttribute]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        private string _Name;

        
        [NotMapped]
        public Article Article
        {
            get { return _Article; }
            set
            {
                _Article = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValueNetto));
                OnPropertyChanged(nameof(ValueBrutto));
            }
        }
        private Article _Article;

        [IsRequiredInt]
        public int? ArticleId
        {
            get { return _ArticleId; }
            set
            {
                _ArticleId = value;
                OnPropertyChanged();
            }
        }
        private int? _ArticleId;

        [IsRequiredInt]
        public int? Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValueNetto));
                OnPropertyChanged(nameof(ValueBrutto));
            }
        }
        private int? _Amount;

        [NotMapped]
        public int ValueNetto => Article != null && Article.NettoValue != null && Amount != null? Article.NettoValue.Value * Amount.Value : 0;

        [NotMapped]
        public int ValueBrutto => Article != null && Amount != null ? Article.BruttoValue * Amount.Value : 0;


    }
}
