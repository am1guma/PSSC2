using OanaMariaPalcu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OanaMariaPalcu.Model
{
    public class Operation
    {
        public static Express val;
        public static Express Sum(Express exp)
        {
            Client.SendValues(exp.Val1, exp.Val2, "+");
            Thread.Sleep(500);
            exp.Result = val.Result;
            return exp;
        }

        public static Express Sub(Express exp)
        {
            Client.SendValues(exp.Val1, exp.Val2, "-");
            Thread.Sleep(500);
            exp.Result = val.Result;
            return exp;
        }

        public static Express Mul(Express exp)
        {
            Client.SendValues(exp.Val1, exp.Val2, "x");
            Thread.Sleep(500);
            exp.Result = val.Result;
            return exp;
        }

        public static Express Div(Express exp)
        {
            Client.SendValues(exp.Val1, exp.Val2, ":");
            Thread.Sleep(500);
            exp.Result = val.Result;
            return exp;
        }

        public static Express Reset(Express exp)
        {
            exp.Val1 = "";
            exp.Val2 = "";
            exp.Result = "";
            return exp;
        }
    }
}
