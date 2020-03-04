using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemOperations
{
    public class GetArticleTypes : CommonSystemOperation
    {
        public ArticleType ArticleType { get; private set; }
        protected override object ExecuteSpecificOperation(IDomainObject obj)
        {      
            ArticleType = (ArticleType)obj;
            return Broker.Instance.GetList(obj).OfType<ArticleType>().ToList();
        }

        protected override void Validation(IDomainObject obj)
        {
            if (!(obj is ArticleType))
            {
                throw new ArgumentException();
            }
        }
    }
}
