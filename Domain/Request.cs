using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Request
    {
        public Operation Operation { get; set; }
        public object Object { get; set; }
    }
    public enum Operation
    {
        EmployeeLogin,
        CustomerLogin,
        CustomerRegistration,
        GetAllArticles,
        Validation,
        GetAllArticleTypes,
        GetAllManufacturers,
        GetArticles,
        AddArticle,
        DeleteArticle,
        UpdateArticle,
        AddBill,
        GetBills,
        GetEmployees,
        SearchArticles
    }
}
