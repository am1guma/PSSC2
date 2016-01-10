using OanaMariaPalcu.Model;
using OanaMariaPalcu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OanaMariaPalcu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Express exp;
        public MainWindow()
        {
            InitializeComponent();
            exp = new Express();
            Client.SignIn();
            Operation.val = new Express();
            this.DataContext = exp;
        }

        private void Button_Click_Sum(object sender, RoutedEventArgs e)
        {
            this.DataContext = Operation.Sum(exp);
        }

        private void Button_Click_Sub(object sender, RoutedEventArgs e)
        {
            this.DataContext = Operation.Sub(exp);
        }

        private void Button_Click_Mul(object sender, RoutedEventArgs e)
        {
            this.DataContext = Operation.Mul(exp);
        }

        private void Button_Click_Div(object sender, RoutedEventArgs e)
        {
            this.DataContext = Operation.Div(exp);
        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            this.DataContext = Operation.Reset(exp);
        }
    }
}
