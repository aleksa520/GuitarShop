using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemOperations
{
    public class GetManufacturers : CommonSystemOperation
    {
        public Manufacturer Manufacturer { get; private set; }
        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Manufacturer = (Manufacturer)obj;
            return Broker.Instance.GetList(obj).OfType<Manufacturer>().ToList();
        }

        protected override void Validation(IDomainObject obj)
        {
            if (!(obj is Manufacturer))
            {
                throw new ArgumentException();
            }
        }
    }
}
