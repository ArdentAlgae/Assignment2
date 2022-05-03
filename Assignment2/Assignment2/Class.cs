using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Class
    {
        public string unitCode { get; set; }
        public string campus { get; set; }
        public string day { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
        public string type { get; set; }
        public string room { get; set; }
        public int staff { get; set; }
        public Class()
        {

        }
        public Class(object[] rowData)
        {
            unitCode = (string)rowData[0];
            campus = (string)rowData[1];
            day = (string)rowData[2];
            startTime = (TimeSpan) rowData[3];
            endTime = (TimeSpan) rowData[4];
            type = (string)rowData[5];
            room = (string)rowData[6];
            staff = (int)rowData[7];
        }
    }
}
