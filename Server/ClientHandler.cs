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
                Request request;
                try
                {
                request = (Request)formatter.Deserialize(stream);
                }
                catch (Exception)
                {
                    return;
                    //Communication.Instance.ShowMessageBox("Client Has Exited!");                    
                }
                Response response = new Response();
                try
                {
                    Customer cust = null;
                    Customer foundCustomer = null;
                    Employee emp = null;
                    Employee foundEmployee = null;

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
