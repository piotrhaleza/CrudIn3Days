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
    public class ClientService : SaveReuqimentService<Client,V_Client>, IClientService
    {
        public ClientService(BaseContext context) : base(context)
        {

        }
        public override List<V_Client> GetAllItems()
        {
            return Context.V_Clients.ToList();
        }

        public override Client GetItem(int id)
        {
            return Context.Clients.FirstOrDefault(x => x.Id == id);
        }

        public override void UpdateItem(Client saveItem)
        {
            new ClientCopier().LowCopy(saveItem, Context.Clients.FirstOrDefault(x => x.Id == saveItem.Id));
        }
    }
}
