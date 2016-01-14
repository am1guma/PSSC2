using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OanaMariaPalcu.ViewModel
{
    public class GraficData
    {
        public double X { get; set; }
        public double Y { get; set; }

        public GraficData(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
