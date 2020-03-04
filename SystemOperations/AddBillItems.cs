using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOperations
{
    public class AddBillItems : CommonSystemOperation
    {
        public Item Item { get; set; }
        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Item = (Item)obj;

            int id = Broker.Instance.GetId(Item);
            if (id == 1)
            {
                Item.Id = 1;
            }
            else
            {
                Item.Id = id + 1;
            }
            return Broker.Instance.Add(Item);
        }

        protected override void Validation(IDomainObject obj)
        {
            if (!(obj is Item))
            {
                throw new ArgumentException();
            }
        }
    }
}
