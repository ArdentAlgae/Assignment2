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
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string type { get; set; }
        public string room { get; set; }
        public string staff { get; set; }
        public Class()
        {

        }
        public Class(object[] rowData)
        {
            unitCode = (string)rowData[0];
            campus = (string)rowData[1];
            day = (string)rowData[2];
            type = (string)rowData[5];
            room = (string)rowData[6];
        }
    }
}
