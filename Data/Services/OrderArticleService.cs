using Models.Models;
using Models.Prototypes;
using Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class OrderArticleService : SaveReuqimentService<OrderArticle, V_OrderArticle>, IOrderArticleService
    {
        public OrderArticleService(BaseContext context) : base(context)
        {

        }

        public  override List<V_OrderArticle> GetAllItems()
        {
            return Context.V_OrderArticles.ToList();
        }
        public override OrderArticle GetItem(int id)
        {
           var orderArticle = Context.OrderArticles.FirstOrDefault(x => x.Id == id);
            orderArticle.Article = Context.Articles.FirstOrDefault(x => x.Id == orderArticle.ArticleId);
            return orderArticle;
        }
        public override void UpdateItem(OrderArticle saveItem)
        {
            new OrderArticleCopier().LowCopy(saveItem, Context.OrderArticles.FirstOrDefault(x => x.Id == saveItem.Id));
        }
    }
}
