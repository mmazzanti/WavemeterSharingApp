using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleService4Debug
{
    class WMChannel
    {
        //private double Wavelengths = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double Wavelength { get; set; }
        public int Channel { get; set; }
        //public Dictionary<string, double> Wavelens { get; set; }
        //public int TemperatureCelsius { get; set; }
        /*public double this[int i]
        {
            get { return Wavelengths[i]; }
            set { Wavelengths[i] = value; }
        }

        public void SetWL(int i,double WL)
        {
            Wavelengths[i] = WL;
        }
        public double GetWL(int i)
        {
            return Wavelengths[i];
        }*/

        
    }
}
