using System;
using System.Net.Http;
using System.Windows;
using Microsoft.AspNet.SignalR.Client;

namespace OanaMariaPalcu.Model
{
    public class Client
    {
        public static string user { get; set; }
        public static IHubProxy proxy { get; set; }
        const string server = "http://localhost:8070/signalr";
        public static HubConnection con { get; set; }
        public static void SendValues(string val1, string val2,string operation)
        {
            string sendMessage = val1 + " " + operation + " " + val2;
            proxy.Invoke("Send", user, sendMessage);
        }
        
        private static void ConnectionClosed()
        {
            var dispatcher = Application.Current.Dispatcher;
        }
        public static void SignIn()
        {
            user = "Oana";
            ConnectAsync();
        }
        private static async void ConnectAsync()
        {
            con = new HubConnection(server);
            con.Closed += ConnectionClosed;
            proxy = con.CreateHubProxy("CustomHub");
            proxy.On<string, string>("AddMessage", (name, message) =>
                Operation.val.Result = message
            );
            try
            {
                await con.Start();
            }
            catch (HttpRequestException)
            {
                return;
            }
        }
    }
}
