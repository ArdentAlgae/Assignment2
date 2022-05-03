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
    /// Interaction logic for EditStaffView.xaml
    /// </summary>
    public partial class EditStaffView : UserControl
    {
        public EditStaffView(Staff staff)
        {
            InitializeComponent();

            staffIDTextBox.Text = staff.staffID.ToString();
            givenNameTextBox.Text = staff.givenName;
            familyNameTextBox.Text = staff.familyName;
            titleTextBox.Text = staff.title;
            campusTextBox.Text = staff.campus;
            roomTextBox.Text = staff.room;
            phoneTextBox.Text = staff.phone.ToString();
            emailTextBox.Text = staff.email;
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Save class?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Staff newStaff = new Staff();
                newStaff.staffID = Int32.Parse(staffIDTextBox.Text);

                EditStaffView view = new EditStaffView(newStaff);
                Body.setBody(view);
            }
        }

        private void DiscardButton_Clicked(object sender, RoutedEventArgs e)
        {
            HomeView home = new HomeView();
            Body.setBody(home);
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            HomeView home = new HomeView();
            Body.setBody(home);
        }
    }
}
