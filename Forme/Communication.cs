using Domain;
using System;
using System.Collections.Generic;
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

        private Communication()
        {
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

        internal bool Validation(string username)
        {
            Employee emp = new Employee
            {
                Username = username
            };

            Request req = new Request
            {
                Operation = Operation.Validation,
                Object = emp
            };

            formatter.Serialize(stream, req);

            Response res = (Response)formatter.Deserialize(stream);

            if(res.Signal == Signal.Ok)
            {
                return true;
            }
            else
            {
                return false;
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
