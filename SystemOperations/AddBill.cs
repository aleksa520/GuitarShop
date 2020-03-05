using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOperations
{
    public class AddBill : CommonSystemOperation
    {
        public Bill Bill { get; private set; }

        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Bill = (Bill)obj;
            Bill.Date = DateTime.Now;

            Broker.Instance.Add(obj);


            int billId = Broker.Instance.GetId(Bill);

            foreach (var item in Bill.Items)
            {
                item.Bill = Bill;
                item.Bill.Id = billId;
            }

            foreach (var item in Bill.Items)
            {
                int itemId = Broker.Instance.GetId(item);
                if (itemId == 0)
                {
                    item.Id = 1;
                }
                else
                {
                    item.Id = itemId + 1;
                }
                Broker.Instance.Add(item);
            }
            return true;
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
