using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Assignment2
{
    class Body
    {
        public static void setBody(UserControl body)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            main.setBody(body);
        }
    }
}
