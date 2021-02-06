using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PT1._0
{
    class Functions
    {


        [DllImport("okawsp6.dll", EntryPoint = "wspPST")]
        public static extern double wspPST(double t);
        [DllImport("okawsp6.dll", EntryPoint = "wspHPT")]
        public static extern double wspHPT(double p, double t);

        [DllImport("okawsp6.dll", EntryPoint = "wspVPT")]
        public static extern double wspVPT(double p, double t);
        [DllImport("okawsp6.dll", EntryPoint = "wspVSST")]
        public static extern double wspVSST(double t);
        [DllImport("okawsp6.dll", EntryPoint = "wspVSWT")]
        public static extern double wspVSWT(double t);
        [DllImport("okawsp6.dll", EntryPoint = "wspSSST")]
        public static extern double wspSSST(double t);
        [DllImport("okawsp6.dll", EntryPoint = "wspSSWT")]
        public static extern double wspSSWT(double t);

        [DllImport("okawsp6.dll", EntryPoint = "wspVPH")]
        public static extern double wspVPH(double p, double h);
        [DllImport("okawsp6.dll", EntryPoint = "wspXPH")]
        public static extern double wspXPH(double p, double h);
        [DllImport("okawsp6.dll", EntryPoint = "wspSPT")]
        public static extern double wspSPT(double p, double h);
        [DllImport("okawsp6.dll", EntryPoint = "wspSPH")]
        public static extern double wspSPH(double p, double h);
        [DllImport("okawsp6.dll", EntryPoint = "wspPHS")]
        public static extern double wspPHS(double h, double s);
        [DllImport("okawsp6.dll", EntryPoint = "wspTHS")]
        public static extern double wspTHS(double h, double s);
        [DllImport("okawsp6.dll", EntryPoint = "wspVHS")]
        public static extern double wspVHS(double h, double s);
        [DllImport("okawsp6.dll", EntryPoint = "wspXHS")]
        public static extern double wspXHS(double h, double s);
        [DllImport("okawsp6.dll", EntryPoint = "wspTPH")]
        public static extern double wspTPH(double p, double h);
        [DllImport("okawsp6.dll", EntryPoint = "wspVPS")]
        public static extern double wspVPS(double p, double s);
        [DllImport("okawsp6.dll", EntryPoint = "wspDYNVISHS")]
        public static extern double wspDYNVISHS(double h, double s);
        [DllImport("okawsp6.dll", EntryPoint = "wspHSTX")]
        public static extern double wspHSTX(double t, double x);
        [DllImport("okawsp6.dll", EntryPoint = "wspTSP")]
        public static extern double wspTSP(double p);
        [DllImport("okawsp6.dll", EntryPoint = "wspHPS")]
        public static extern double wspHPS(double p, double s);
        [DllImport("okawsp6.dll", EntryPoint = "wspTPS")]
        public static extern double wspTPS(double p, double s);

        public static string s = Path.GetFullPath("okawsp6.dll");
    }
}
