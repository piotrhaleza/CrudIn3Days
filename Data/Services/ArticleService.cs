using Models.Attributes;
using Models.Models;
using Models.Prototypes;
using Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ArticleService : SaveReuqimentService<Article,V_Article>, IArticleService
    {
        public ArticleService(BaseContext context) : base(context)
        {

        }

        public override List<V_Article> GetAllItems()
        {
            return Context.V_Articles.ToList();
        }

        public override Article GetItem(int id)
        {
            return Context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public override void UpdateItem(Article saveItem)
        {
            new ArticleCopier().LowCopy(saveItem, Context.Articles.FirstOrDefault(x => x.Id == saveItem.Id));
        }
    }
}