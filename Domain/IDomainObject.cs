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
        //string Search(string s);
        //string UslovLog(string s1, string s2);
        //string UslovSe(int s1, int s2);
        string SearchId { get; }
        object ColumnId { get; }
        object Get { get; }
        string Criteria { get; set; }
        List<IDomainObject> GetReaderResult(SqlDataReader reader);
    }
}
