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
            try
            {
                string sendMessage = val1 + " " + operation + " " + val2;
                proxy.Invoke("Send", user, sendMessage);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private static void ConnectionClosed()
        {
            try
            {
                var dispatcher = Application.Current.Dispatcher;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
        public static void SignIn()
        {
            try
            {
                user = "Oana";
                ConnectAsync();
            }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
}
        private static async void ConnectAsync()
        {
            try
            {
                con = new HubConnection(server);
                con.Closed += ConnectionClosed;
                proxy = con.CreateHubProxy("CustomHub");
                proxy.On<string, string>("AddMessage", (name, message) =>
                    Operation.result = message
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
    }
}
