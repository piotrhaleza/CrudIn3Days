using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Prototypes
{
    public class OrderArticleCopier : ILowCopier<OrderArticle>
    {
        public void LowCopy(OrderArticle Source, OrderArticle Result)
        {
            Result.Name = Source.Name;
            Result.Article = Source.Article;
            Result.ArticleId = Source.ArticleId;
            Result.Amount = Source.Amount;
        }
    }
}
