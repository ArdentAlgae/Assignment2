using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for AddClassView.xaml
    /// </summary>
    public partial class AddClassView : UserControl
    {
        public Class class_;

        public AddClassView(Class class_)
        {
            this.class_ = class_;
            InitializeComponent();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DiscardButton_Clicked(object sender, RoutedEventArgs e)
        {
            HomeView home = new HomeView();
            Body.setBody(home);
        }
    }
}
