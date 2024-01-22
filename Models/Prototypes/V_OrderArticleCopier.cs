using Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Prototypes
{
    public class V_OrderArticleCopier : ILowCopier<V_OrderArticle>
    {
        public void LowCopy(V_OrderArticle Source, V_OrderArticle Result)
        {
            Result.Name = Source.Name;
            Result.ArticleName = Source.ArticleName;
            Result.Amount = Source.Amount;
            Result.ValueNetto = Source.ValueNetto;
            Result.ValueBrutto = Source.ValueBrutto;
        }
    }
}
