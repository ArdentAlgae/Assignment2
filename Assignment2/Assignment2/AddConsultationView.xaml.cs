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
    /// Interaction logic for AddConsultationView.xaml
    /// </summary>
    public partial class AddConsultationView : UserControl
    {
        public AddConsultationView(Consultation consultation)
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HomeView home = new HomeView();
            Body.setBody(home);
        }
    }
}
