using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDomainObject
    {
        string Table { get; }
        string FullTable { get; }
        string InsertValues { get; }
        string UpdateValues { get; }
        string Join { get; }
        string SearchWhere();
        string SearchCriteria(int crit);
        string Condition();
        string SearchId { get; }
        object ColumnId { get; }
        object Get { get; }
        string Criteria { get; set; }
        List<IDomainObject> GetReaderResult(SqlDataReader reader);
    }
}
