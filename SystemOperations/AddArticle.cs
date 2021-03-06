﻿using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOperations
{
    public class AddArticle : CommonSystemOperation
    {
        public Article Article { get; private set; }

        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Article = (Article)obj;
            return Broker.Instance.Add(obj);
        }

        protected override void Validation(IDomainObject obj)
        {
            if(!(obj is Article))
            {
                throw new ArgumentException();
            }
        }
    }
}
