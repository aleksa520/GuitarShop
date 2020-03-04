using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemOperations
{
    public class GetBills : CommonSystemOperation
    {
        public Bill Bill { get; private set; }
        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Bill = (Bill)obj;
            return Broker.Instance.GetListFull(obj).OfType<Bill>().ToList();
        }

        protected override void Validation(IDomainObject obj)
        {
            if (!(obj is Bill))
            {
                throw new ArgumentException();
            }
        }
    }
}
