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
using MySql.Data.MySqlClient;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for EditStaffView.xaml
    /// </summary>
    public partial class EditStaffView : UserControl
    {
        public Staff staff_;
        public EditStaffView(Staff staff)
        {
            InitializeComponent();

            staff_ = staff;

            staffIDTextBox.Text = staff.staffID.ToString();
            givenNameTextBox.Text = staff.givenName;
            familyNameTextBox.Text = staff.familyName;
            titleTextBox.Text = staff.title;
            campusTextBox.Text = staff.campus;
            roomTextBox.Text = staff.room;
            phoneTextBox.Text = staff.phone;
            emailTextBox.Text = staff.email;
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Save class?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Staff newStaff = new Staff();
                newStaff.staffID = Int32.Parse(staffIDTextBox.Text);
                newStaff.campus = campusTextBox.Text;
                newStaff.givenName = givenNameTextBox.Text;
                newStaff.familyName = familyNameTextBox.Text;
                newStaff.title = titleTextBox.Text;
                newStaff.phone = phoneTextBox.Text;
                newStaff.room = roomTextBox.Text;
                newStaff.email = emailTextBox.Text;
                newStaff.profile = new byte[0];
                using (var conn = new MySqlConnection("Database=hris;Data Source=alacritas.cis.utas.edu.au;User Id=kit206g2a;Password=group2a"))
                {
                    conn.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("UPDATE staff" +
                        " SET id=@NewID," +
                        " campus=@NewCampus," +
                        " given_name=@NewGivenName," +
                        " family_name=@NewFamilyName," +
                        " title=@NewTitle," +
                        " phone=@NewPhone," +
                        " room=@NewRoom," +
                        " email=@NewEmail" +
                        " WHERE id=@staffID", conn);

                    cmd.Parameters.AddWithValue("@staffID", staff_.staffID);

                    cmd.Parameters.AddWithValue("@NewID", newStaff.staffID);
                    cmd.Parameters.AddWithValue("@NewCampus", newStaff.campus);
                    cmd.Parameters.AddWithValue("@NewGivenName", newStaff.givenName);
                    cmd.Parameters.AddWithValue("@NewFamilyName", newStaff.familyName);
                    cmd.Parameters.AddWithValue("@NewTitle", newStaff.title);
                    cmd.Parameters.AddWithValue("@NewPhone", newStaff.phone);
                    cmd.Parameters.AddWithValue("@NewRoom", newStaff.room);
                    cmd.Parameters.AddWithValue("@NewEmail", newStaff.email);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                StaffView view = new StaffView(newStaff);
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
