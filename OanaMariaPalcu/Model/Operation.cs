using OanaMariaPalcu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OanaMariaPalcu.Model
{
    public class Operation
    {
        public static double[,] GrafData;
        public static string result="";
        public static string Sum(string val1,string val2)
        {
            try
            {
                Client.SendValues(val1, val2, "+");
                Thread.Sleep(500);
                return result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public static string Sub(string val1, string val2)
        {
            try
            { 
                Client.SendValues(val1, val2, "-");
                Thread.Sleep(500);
                return result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public static string Mul(string val1, string val2)
        {
            try
            {
                Client.SendValues(val1, val2, "x");
                Thread.Sleep(500);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }

        }

        public static string Div(string val1, string val2)
        {
            try
            {
                Client.SendValues(val1, val2, ":");
                Thread.Sleep(500);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }

        }

        public static string SolveQuadratic(double a, double b, double c)
        {
            try
            {
                if (a != 0)
                {
                    double sqrtpart = b * b - 4 * a * c;
                    double x, x1, x2, img;
                    if (sqrtpart > 0)
                    {
                        x1 = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);
                        x2 = (-b - System.Math.Sqrt(sqrtpart)) / (2 * a);
                        return x1 + " " + x2;
                    }
                    else if (sqrtpart < 0)
                    {
                        sqrtpart = -sqrtpart;
                        x = -b / (2 * a);
                        img = System.Math.Sqrt(sqrtpart) / (2 * a);
                        return String.Format("{0}+{1}i {0}-{1}i", x, img);
                    }
                    else
                    {
                        x = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);
                        return x + "";
                    }
                }
                else
                {
                    double x = ((-1) * c) / b;
                    return x + "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }

        }

        public static double[,] GetPoints(double a, double b, double c, double x1, double x2)
        {
            try
            {
                double[,] output = new double[11, 2];
                double minim = 0;
                double maxim = 0;
                if (x1 < x2)
                {
                    minim = x1;
                    maxim = x2;
                }
                else
                {
                    minim = x2;
                    maxim = x1;
                }
                minim = Math.Round(minim, 2);
                maxim = Math.Round(maxim, 2);

                output[0, 0] = minim;
                output[0, 1] = GetY(a, b, c, minim);

                output[1, 0] = Medie(minim, maxim);
                output[1, 1] = GetY(a, b, c, output[1, 0]);

                output[2, 0] = Medie(minim, output[1, 0]);
                output[2, 1] = GetY(a, b, c, output[2, 0]);

                output[3, 0] = Medie(output[1, 0], maxim);
                output[3, 1] = GetY(a, b, c, output[3, 0]);

                output[4, 0] = Medie(output[1, 0], output[2, 0]);
                output[4, 1] = GetY(a, b, c, output[4, 0]);

                output[5, 0] = Medie(output[1, 0], output[3, 0]);
                output[5, 1] = GetY(a, b, c, output[5, 0]);

                output[6, 0] = Medie(output[3, 0], output[4, 0]);
                output[6, 1] = GetY(a, b, c, output[6, 0]);

                output[7, 0] = Medie(output[3, 0], output[5, 0]);
                output[7, 1] = GetY(a, b, c, output[7, 0]);

                output[8, 0] = Medie(output[4, 0], output[6, 0]);
                output[8, 1] = GetY(a, b, c, output[8, 0]);

                output[9, 0] = Medie(output[4, 0], maxim);
                output[9, 1] = GetY(a, b, c, output[9, 0]);

                output[10, 0] = maxim;
                output[10, 1] = GetY(a, b, c, maxim);

                return output;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new double[0,0];
            }
        }

        private static double Medie(double a,double b)
        {
            try
            {
                return (a + b) / 2;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new double();
            }
        }

        private static double GetY(double a, double b, double c, double x)
        {
            try
            {
                double answer = (a * x * x) + (b * x) + c;
                return answer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new double();
            }
        }

        public static GraficData GetGrData(int i)
        {
            return new GraficData(GrafData[i, 0], GrafData[i, 1]);
        }
    }
}
