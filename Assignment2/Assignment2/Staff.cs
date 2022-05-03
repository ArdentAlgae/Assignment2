using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Staff
    {
        public int staffID { get; set; }
        public string givenName { get; set; }
        public string familyName { get; set; }
        public string title { get; set; }
        public string campus { get; set; }
        public string phone { get; set; }
        public string room { get; set; }
        public string email { get; set; }
        public Staff()
        {

        }
        public Staff(object[] rowData)
        {
            staffID = (int) rowData[0];
            givenName = (string) rowData[1];
            familyName = (string)rowData[2];
            title = (string) rowData[3];
            campus = (string) rowData[4];
            phone = (string) rowData[5];
            room = (string) rowData[6];
            email = (string) rowData[7];
        }
    }
}
