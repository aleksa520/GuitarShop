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
            Bill bill = (Bill)obj;
            Bill = bill;
            bill.Date = DateTime.Now;

            return broker.Add(obj);
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
