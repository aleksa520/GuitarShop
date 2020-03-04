using Controller;
using Domain;
using Forme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private Socket clientSocket;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();

        public ClientHandler(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            stream = new NetworkStream(clientSocket);
        }

        public void RequestHandler()
        {
            bool end = false;
            while (!end)
            {
                Request request = null;
                try
                {
                request = (Request)formatter.Deserialize(stream);
                }
                catch (Exception)
                {
                    Communication.Instance.ShowMessageBox("Client Has Exited!");                    
                    return;
                }
                Response response = new Response();
                try
                {
                    Customer cust = null;
                    Customer foundCustomer = null;
                    Employee emp = null;
                    Employee foundEmployee = null;
                    Article article = null;
                    Bill bill = null;

                    switch (request.Operation)
                    {
                        case Operation.EmployeeLogin:
                            emp = (Employee)request.Object;
                            foundEmployee = Controller.Controller.Instance.EmployeeLogin(emp.Username, emp.Password);
                            response.Message = "System Found User!";
                            response.Object = foundEmployee;
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.CustomerLogin:
                            cust = (Customer)request.Object;
                            foundCustomer = Controller.Controller.Instance.CustomerLogin(cust.Username, cust.Password);
                            response.Message = "System Found User!";
                            response.Object = foundCustomer;
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.CustomerRegistration:
                            cust = (Customer)request.Object;
                            foundCustomer = Controller.Controller.Instance.CustomerRegistration(cust);
                            response.Message = "System Registered Customer!";
                            response.Object = foundCustomer;
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.Validation:
                            emp = (Employee)request.Object;
                            foundEmployee = Controller.Controller.Instance.Validation(emp);
                            response.Message = "Username Is Available!";
                            response.Object = foundCustomer;
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.GetAllArticleTypes:
                            response.Object = Controller.Controller.Instance.GetAllArticleTypes();
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.GetAllManufacturers:
                            response.Object = Controller.Controller.Instance.GetAllManufacturers();
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.GetArticles:
                            response.Object = Controller.Controller.Instance.GetArticles();
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.AddArticle:
                            article = (Article)request.Object;
                            response.Object = Controller.Controller.Instance.AddArticle(article);
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.DeleteArticle:
                            article = (Article)request.Object;
                            response.Object = Controller.Controller.Instance.DeleteArticle(article);
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.UpdateArticle:
                            article = (Article)request.Object;
                            response.Object = Controller.Controller.Instance.UpdateArticle(article);
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.AddBill:
                            bill = (Bill)request.Object;
                            response.Object = Controller.Controller.Instance.AddBill(bill);
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.GetBills:
                            response.Object = Controller.Controller.Instance.GetBills();
                            formatter.Serialize(stream, response);
                            break;
                    }
                }
                catch (Exception e)
                {
                    response.Signal = Signal.Error;
                    response.Message = e.Message;
                    formatter.Serialize(stream, response);
                }
            }
        }
    }
}
