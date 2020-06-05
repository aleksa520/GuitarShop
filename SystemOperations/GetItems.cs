using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemOperations
{
    public class GetItems : CommonSystemOperation
    {
        public Item Item { get; private set; }
        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Item = (Item)obj;
            return Broker.Instance.GetListFull(obj).OfType<Item>().ToList();
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
