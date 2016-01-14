using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using OanaMariaPalcu.Model;
using System.Windows.Forms;

namespace OanaMariaPalcu.ViewModel
{
    public class GraficBind : Collection<GraficData>
    {
        public GraficBind()
        {
            try
            {
                for (int i = 0; i < 11; i++)
                {
                    Add(Operation.GetGrData(i));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
