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
            ButtonStart.IsEnabled = false;
            Task.Run(() => Start());
        }
        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            sg.Dispose();
            Close();
            MessageBox.Show("Server stopped.");
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
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    public class CustomHub : Hub
    {
        public void Send(string name, string message)
        {
            string[] mes = message.Split(' ');
            string res = "";
            switch(mes[1])
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
    }
}
