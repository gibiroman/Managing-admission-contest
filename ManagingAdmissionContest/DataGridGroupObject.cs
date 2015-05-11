using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagingAdmissionContest
{
    class DataGridGroupObject
    {
        public string id { get; set; }      //this will be match id column
        public string firstname { get; set; } // this will be match firstname column
        public string lastname { get; set; }
        public double bacgrade { get; set; }
        public double examgrade { get; set; }
        public double csgrade { get; set; }
        public double mathgrade { get; set; }
    }
}
