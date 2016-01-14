using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
namespace Server
{

    public partial class MainWindow : Window
    {
        public IDisposable sg { get; set; }
        const string server = "http://localhost:8070";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ButtonStart.IsEnabled = false;
                Task.Run(() => Start());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sg.Dispose();
                Close();
                MessageBox.Show("Server stopped.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Start()
        {
            try
            {
                sg = WebApp.Start(server);
            }
            catch (TargetInvocationException)
            {
                MessageBox.Show("Cannot Start server.");
                this.Dispatcher.Invoke(() => ButtonStart.IsEnabled = true);
                return;
            }
            this.Dispatcher.Invoke(() => ButtonStop.IsEnabled = true);
            MessageBox.Show("Server started.");
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            try
            {
                app.UseCors(CorsOptions.AllowAll);
                app.MapSignalR();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
    }
    public class CustomHub : Hub
    {
        public void Send(string name, string message)
        {
            try
            {
                string[] mes = message.Split(' ');
                string res = "";
                switch (mes[1])
                {
                    case "+":
                        res = (Convert.ToDouble(mes[0]) + Convert.ToDouble(mes[2])).ToString();
                        break;
                    case "-":
                        res = (Convert.ToDouble(mes[0]) - Convert.ToDouble(mes[2])).ToString();
                        break;
                    case "x":
                        res = (Convert.ToDouble(mes[0]) * Convert.ToDouble(mes[2])).ToString();
                        break;
                    case ":":
                        res = (Convert.ToDouble(mes[0]) / Convert.ToDouble(mes[2])).ToString();
                        break;
                }
                Clients.All.addMessage(name, res);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
