//WavemeterService A Windows service for sharing Wavelengths information in a network
//Copyright (C) 2021  Matteo Mazzanti

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <https://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WavemeterService
{
    class WMChannel
    {
        private long PatternSize;
        private IntPtr Patternhglobal;
        private long PatternitemsCnt;
        private long PatternitemsSize;
        private long AnalysisSize;
        private IntPtr Analysishglobal;
        private long AnalysisitemsCnt;
        private long AnalysisitemsSize;
        //private double Wavelengths = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int Channel { get; set; }
        public double Frequency { get; set; }
        public int[] PatternData;
        public int[] AnalysisData;
        ~WMChannel()
        {
            // Free allocated memory at the destruction
            Marshal.FreeHGlobal(Patternhglobal);
            Marshal.FreeHGlobal(Analysishglobal);
        }

        //public Dictionary<string, double> Wavelens { get; set; }
        //public int TemperatureCelsius { get; set; }
        /*public double this[int i]
        {
            get { return Wavelengths[i]; }
            set { Wavelengths[i] = value; }
        }
        */
        public void SetPatternSize(long Cnt, long Size)
        {
            PatternSize = Cnt * Size;
            PatternitemsCnt = Cnt;
            PatternitemsSize = Size;
            Patternhglobal = Marshal.AllocHGlobal((int)PatternSize);
        }
        public void SetAnalysisSize(long Cnt,long Size)
        {
            AnalysisSize = Cnt*Size;
            AnalysisitemsCnt = Cnt;
            AnalysisitemsSize = Size;
            Analysishglobal = Marshal.AllocHGlobal((int)AnalysisSize);
        }
        public long GetAnalysisSize()
        {
            return AnalysisSize;
        }
        public long GetPatternItemSize()
        {
            return PatternitemsSize;
        }
        public long GetPatternItemCnt()
        {
            return PatternitemsCnt;
        }
        public long GetPatternSize()
        {
            return PatternSize;
        }
        public IntPtr GetPatternPtr()
        {
            return Patternhglobal;
        }
        public IntPtr GetAnalysisPtr()
        {
            return Analysishglobal;
        }

        public void SetPatternDataFromPtr()
        {
            PatternData = new int[PatternitemsCnt]; // Where to store the pattern data
            for (int el = 0; el < PatternSize;)
            {
                int tmp = 0;
                for (int bits = 0; bits < PatternitemsSize; bits++)
                {
                    tmp = tmp | Marshal.ReadByte(Patternhglobal, el+bits) << bits * 8; //Shift each byte by item# * 8 bit (first one shift by 0, second by 8 bits etc..) 
                }
                //PatternData[el] = Marshal.ReadByte(Patternhglobal, el) | Marshal.ReadByte(Patternhglobal, el + 1) << 8 | Marshal.ReadByte(Patternhglobal, el + 2) << 16 | Marshal.ReadByte(Patternhglobal, el + 3) << 24;
                el += (int)PatternitemsSize;
                PatternData[el/PatternitemsSize-1] = tmp;
            }
        }



    }
}
