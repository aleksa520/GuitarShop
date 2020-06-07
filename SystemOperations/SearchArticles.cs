using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using DatabaseBroker;
using System.Linq;

namespace SystemOperations
{
    public class SearchArticles : CommonSystemOperation
    {
        public Article Article { get; private set; }
        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {
            Article article = (Article)obj;
            Article = article;
            return Broker.Instance.Search(obj).OfType<Article>().ToList();
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
