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
    public class OrderService : SaveReuqimentService<Order, V_Order>, IOrderService
    {
        public OrderService(BaseContext context) : base(context)
        {

        }

        public override List<V_Order> GetAllItems()
        {
            return Context.V_Orders.ToList();
        }

        public override Order GetItem(int id)
        {
            var result =Context.Orders.FirstOrDefault(x => x.Id == id);
            var order_orderArticles = Context.Order_OrderArticles.Where(x => x.OrderId == result.Id).Select(x => x.OrderArticleId).ToArray();
            result.OrderArticles = Context.V_OrderArticles.Where(x => order_orderArticles.Contains(x.Id)).ToList();
            return result;

        }
        public override async void UpdateItem(Order saveItem)
        {
            var oldValue = Context.Orders.FirstOrDefault(x => x.Id == saveItem.Id);


            foreach (var newItem in saveItem.Added_OrderArticles)
                    await Context.Order_OrderArticles.AddAsync(new Order_OrderArticle() { OrderId = saveItem.Id, OrderArticleId = newItem.Id });

            foreach (var deletedItem in saveItem.Deleted_OrderArticles)
                    Context.Order_OrderArticles.Remove(Context.Order_OrderArticles.FirstOrDefault(x => x.OrderId == saveItem.Id && x.OrderArticleId == deletedItem.Id));

            saveItem.Added_OrderArticles = new List<V_OrderArticle>();
            saveItem.Deleted_OrderArticles = new List<V_OrderArticle>();

            new OrderCopier().LowCopy(saveItem, oldValue);
        }
        public override async Task<bool> Save(Order saveItem)
        {
            bool isNew = saveItem.Id == 0;

            var canSave = CanSave(saveItem);
            if (canSave)
            {
                if (saveItem.Id == 0)
                    await Context.AddAsync(saveItem);
                else
                    UpdateItem(saveItem);

                await Context.SaveChangesAsync();

                if (isNew)
                    foreach (var item in saveItem.OrderArticles)
                        await Context.AddAsync(new Order_OrderArticle() { OrderId = saveItem.Id, OrderArticleId = item.Id });
                await Context.SaveChangesAsync();
            }
            return canSave;
        }

    }
}
