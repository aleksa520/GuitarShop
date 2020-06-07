using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Forme
{
    public class Communication
    {
        private static Communication instance;
        private Socket clientSocket;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();
        private Communication()
        {
        }

        internal List<Bill> GetBills()
        {
            Request req = new Request()
            {
                Operation = Operation.GetBills
            };

            formatter.Serialize(stream, req);
            Response res = (Response)formatter.Deserialize(stream);

            return (List<Bill>)res.Object;
        }

        internal List<Employee> GetEmployees()
        {
            Request req = new Request()
            {
                Operation = Operation.GetEmployees
            };

            formatter.Serialize(stream, req);
            Response res = (Response)formatter.Deserialize(stream);

            return (List<Employee>)res.Object;
        }

        internal List<Article> GetArticles()
        {
            Request req = new Request()
            {
                Operation = Operation.GetArticles
            };

            formatter.Serialize(stream, req);
            Response res = (Response)formatter.Deserialize(stream);

            return (List<Article>)res.Object;
        }
        internal List<Article> SearchArticles(string critearia)
        {
            Request req = new Request()
            {
                Operation = Operation.SearchArticles,
                Object = critearia
            };
            formatter.Serialize(stream, req);
            Response res = (Response)formatter.Deserialize(stream);
            return (List<Article>)res.Object;
        }

        internal bool AddBill(Bill bill)
        {
            Request req = new Request()
            {
                Operation = Operation.AddBill,
                Object = bill
            };

            formatter.Serialize(stream, req);
            Response res = (Response)formatter.Deserialize(stream);

            return (bool)res.Object;
        }

        internal List<ArticleType> GetArticleTypes()
        {
            Request req = new Request()
            {
                Operation = Operation.GetAllArticleTypes
            };

            formatter.Serialize(stream, req);
            Response res = (Response)formatter.Deserialize(stream);

            return (List<ArticleType>)res.Object;
        }

        internal List<Manufacturer> GetManufacturers()
        {
            Request req = new Request()
            {
                Operation = Operation.GetAllManufacturers
            };

            formatter.Serialize(stream, req);
            Response res = (Response)formatter.Deserialize(stream);

            return (List<Manufacturer>)res.Object;
        }

        internal bool AddArticle(Article article)
        {
            Request req = new Request()
            {
                Operation = Operation.AddArticle,
                Object = article
            };

            formatter.Serialize(stream, req);
            Response res = (Response)formatter.Deserialize(stream);

            return (bool)res.Object;
        }

        internal bool DeleteArticle(Article article)
        {
            Request req = new Request()
            {
                Operation = Operation.DeleteArticle,
                Object = article
            };

            formatter.Serialize(stream, req);
            Response res = (Response)formatter.Deserialize(stream);

            return (bool)res.Object;
        }

        internal bool UpdateArticle(Article article)
        {
            Request req = new Request()
            {
                Operation = Operation.UpdateArticle,
                Object = article
            };

            formatter.Serialize(stream, req);
            Response res = (Response)formatter.Deserialize(stream);

            return (bool)res.Object;
        }

        public static Communication Instance
        {
            get
            {
                if (instance == null) instance = new Communication();
                return instance;
            }
        }

        public void ShowMessageBox(string message)
        {
            MessageBox messageBox = new MessageBox(message);
            messageBox.ShowDialog();
        }

        internal Customer CustomerRegistration(string firstName, string lastName, string username, string password)
        {
            Customer cust = new Customer
            {
                FirstName = firstName,
                Username = username,
                LastName = lastName,
                Password = password
            };

            Request req = new Request
            {
                Operation = Operation.CustomerRegistration,
                Object = cust
            };

            formatter.Serialize(stream, req);
            Response res = (Response)formatter.Deserialize(stream);

            if(res.Signal == Signal.Ok)
            {
                return (Customer)res.Object;
            }
            else
            {
                return null;
            }
        }

        internal Employee EmployeeLogin(string username, string password)
        {
            Employee emp = new Employee { Username = username, Password = password };
            Request req = new Request { Operation = Operation.EmployeeLogin, Object = emp };

            formatter.Serialize(stream, req);

            Response res = (Response)formatter.Deserialize(stream);
            
            if (res.Signal == Signal.Ok)
            {
                return (Employee)res.Object;
            }
            else
            {
                return null;
            }
        }

        internal Customer CustomerLogin(string username, string password)
        {
            Customer cust = new Customer { Username = username, Password = password };
            Request req = new Request { Operation = Operation.CustomerLogin, Object = cust };

            formatter.Serialize(stream, req);

            Response res = (Response)formatter.Deserialize(stream);

            if (res.Signal == Signal.Ok)
            {
                return (Customer)res.Object;
            }
            else
            {
                return null;
            }
        }

        public bool Connect()
        {
            try
            {
                if(clientSocket == null || !clientSocket.Connected)
                {
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    clientSocket.Connect("localhost", 9090);
                    stream = new NetworkStream(clientSocket);
                }
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }
    }
}
