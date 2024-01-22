using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Prototypes
{
    public class ArticleCopier : ILowCopier<Article>
    {
        public void LowCopy(Article Source, Article Result)
        {
            Result.Name = Source.Name;
            Result.NettoValue = Source.NettoValue;
            Result.VatTax = Source.VatTax;
        }
    }
}
