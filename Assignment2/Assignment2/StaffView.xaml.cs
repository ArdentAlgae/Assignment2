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
using System.IO;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for StaffView.xaml
    /// </summary>
    public partial class StaffView : UserControl
    {
        private Staff _staff;

        public StaffView(Staff staff)
        {
            InitializeComponent();

            _staff = staff;

            staffIDTextBox.Text = staff.staffID.ToString();
            givenNameTextBox.Text = staff.givenName;
            familyNameTextBox.Text = staff.familyName;
            titleTextBox.Text = staff.title;
            campusTextBox.Text = staff.campus;
            roomTextBox.Text = staff.room;
            phoneTextBox.Text = staff.phone;
            emailTextBox.Text = staff.email;

            if (staff.profile.Length != 0) {
                MemoryStream stream = new MemoryStream(staff.profile);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
                profile.Source = image;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditStaffView view = new EditStaffView(_staff);
            Body.setBody(view);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            HomeView home = new HomeView();
            Body.setBody(home);
        }
    }
}
