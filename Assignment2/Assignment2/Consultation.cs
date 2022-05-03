using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Consultation
    {
        public int staffID { get; set; }
        public string day { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
        public Consultation()
        {

        }
        public Consultation(object[] rowData)
        {
            staffID = (int) rowData[0];
            day = (string) rowData[1];
            startTime = (TimeSpan) rowData[2];
            endTime = (TimeSpan) rowData[3];
        }
    }
}
