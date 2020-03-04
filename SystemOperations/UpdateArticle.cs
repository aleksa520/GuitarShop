using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOperations
{
    public class UpdateArticle : CommonSystemOperation
    {
        public Article Article { get; private set; }
        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Article article = (Article)obj;
            Article = article;
            return Broker.Instance.Update(obj);
        }

        protected override void Validation(IDomainObject obj)
        {
            if (!(obj is Article))
            {
                throw new ArgumentException();
            }
        }
    }
}
