using GalaSoft.MvvmLight.Command;
using OanaMariaPalcu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OanaMariaPalcu.ViewModel
{
    public class Express:ObservableObject
    {
        private string _val1;
        private string _val2;
        private string _result;
        public string Val1
        {
            get { return _val1; }
            set
            {
                _val1 = value;
                OnPropertyChanged("Val1");
            }
        }
        public string Val2
        {
            get { return _val2; }
            set
            {
                _val2 = value;
                OnPropertyChanged("Val2");
            }
        }
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }
    }
}
