using GalaSoft.MvvmLight.Command;
using OanaMariaPalcu.Model;
using OanaMariaPalcu.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OanaMariaPalcu.ViewModel
{
    public class CalculatorViewModel : ObservableObject
    {
        public CalculatorViewModel()
        {
            Expression = new Express();
        }

        public Express Expression { get; set; }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(() =>
                {
                    Expression.Result = Operation.Sum(Expression.Val1, Expression.Val2);
                }));
            }
        }

        private RelayCommand _subCommand;
        public RelayCommand SubCommand
        {
            get
            {
                return _subCommand ?? (_subCommand = new RelayCommand(() =>
                {
                    Expression.Result = Operation.Sub(Expression.Val1, Expression.Val2);
                }));
            }
        }

        private RelayCommand _mulCommand;
        public RelayCommand MulCommand
        {
            get
            {
                return _mulCommand ?? (_mulCommand = new RelayCommand(() =>
                {
                    Expression.Result = Operation.Mul(Expression.Val1, Expression.Val2);
                }));
            }
        }

        private RelayCommand _divCommand;
        public RelayCommand DivCommand
        {
            get
            {
                return _divCommand ?? (_divCommand = new RelayCommand(() =>
                {
                    Expression.Result = Operation.Div(Expression.Val1, Expression.Val2);
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
                    Expression.Val1 = "";
                    Expression.Val2 = "";
                    Expression.Result = "";
                }));
            }
        }

        private RelayCommand _adaugareFunctieCommand;
        public RelayCommand AdaugareFunctieCommand
        {
            get
            {
                return _adaugareFunctieCommand ?? (_adaugareFunctieCommand = new RelayCommand(() =>
                {
                    AdaugareFunctie af = new AdaugareFunctie();
                    af.Show();
                }));
            }
        }
    }
}
