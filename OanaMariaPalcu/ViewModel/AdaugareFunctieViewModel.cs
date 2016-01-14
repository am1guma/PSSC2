using GalaSoft.MvvmLight.Command;
using OanaMariaPalcu.Model;
using OanaMariaPalcu.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OanaMariaPalcu.ViewModel
{
    public class AdaugareFunctieViewModel : ObservableObject
    {
        public AdaugareFunctieViewModel()
        {
        }

        private string _a;
        private string _b;
        private string _c;
        private string _x1;
        private string _x2;
        public string A
        {
            get { return _a; }
            set
            {
                _a = value;
                OnPropertyChanged("A");
            }
        }
        public string B
        {
            get { return _b; }
            set
            {
                _b = value;
                OnPropertyChanged("B");
            }
        }
        public string C
        {
            get { return _c; }
            set
            {
                _c = value;
                OnPropertyChanged("C");
            }
        }
        public string X1
        {
            get { return _x1; }
            set
            {
                _x1 = value;
                OnPropertyChanged("X1");
            }
        }
        public string X2
        {
            get { return _x2; }
            set
            {
                _x2 = value;
                OnPropertyChanged("X2");
            }
        }

        private RelayCommand _aflareRadaciniCommand;
        public RelayCommand AflareRadaciniCommand
        {
            get
            {
                return _aflareRadaciniCommand ?? (_aflareRadaciniCommand = new RelayCommand(() =>
                {
                    string result = Operation.SolveQuadratic(Convert.ToDouble(A), Convert.ToDouble(B), Convert.ToDouble(C));
                    string[] splittedResult = result.Split(' ');
                    if(splittedResult.Length==2)
                    {
                        X1 = splittedResult[0];
                        X2 = splittedResult[1];
                    }
                    else
                    {
                        X1 = X2 = splittedResult[0];
                    }
                }));
            }
        }

        private RelayCommand _graficCommand;
        public RelayCommand GraficCommand
        {
            get
            {
                return _graficCommand ?? (_graficCommand = new RelayCommand(() =>
                {
                    Operation.GrafData = Operation.GetPoints(Convert.ToDouble(A), Convert.ToDouble(B), Convert.ToDouble(C), Convert.ToDouble(X1), Convert.ToDouble(X2));
                    Chart c = new Chart();
                    c.Show();
                                 
                }));
            }
        }

        private RelayCommand _resetCommand;
        public RelayCommand ResetCommand
        {
            get
            {
                return _resetCommand ?? (_resetCommand = new RelayCommand(() =>
                {
                    A = "";
                    B = "";
                    C = "";
                    X1 = "";
                    X2 = "";
                }));
            }
        }
    }
}
