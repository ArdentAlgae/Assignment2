using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Unit
    {
        public string unitCode { get; set; }
        public string unitName { get; set; }
        public int unitCoordinator { get; set; }
        public Unit(object[] rowData)
        {
            unitCode = (string) rowData[0];
            unitName = (string) rowData[1];
            unitCoordinator = (int) rowData[2];
        }
    }
}
