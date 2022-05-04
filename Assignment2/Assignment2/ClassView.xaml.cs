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
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for AddClassView.xaml
    /// </summary>
    public partial class ClassView : UserControl
    {
        Class class_;
        public ClassView(Class class_)
        {
            this.class_ = class_;
            InitializeComponent();

            unitCodeText.Text = class_.unitCode;
            campusText.Text = class_.campus;
            dayText.Text = class_.day;
            startTimeText.Text = class_.startTime.ToString();
            endTimeText.Text = class_.endTime.ToString();
            typeText.Text = class_.type;
            roomText.Text = class_.room;
            staffText.Text = class_.staff.ToString();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HomeView home = new HomeView();
            Body.setBody(home);
        }

        private void editButtonClicked(object sender, RoutedEventArgs e)
        {
            EditClassView view = new EditClassView(class_);
            Body.setBody(view);
        }

        private void deleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this class? This cannot be undone.", "Confirmation", MessageBoxButton.OKCancel) == MessageBoxResult.Yes)
            {
                using (var conn = new MySqlConnection("Database=hris;Data Source=alacritas.cis.utas.edu.au;User Id=kit206g2a;Password=group2a"))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM class" +
                            " WHERE unit_code=@UnitCode" +
                            " AND campus=@Campus" +
                            " AND day=@Day" +
                            " AND start=@StartTime", conn);

                    cmd.Parameters.AddWithValue("@UnitCode", class_.unitCode);
                    cmd.Parameters.AddWithValue("@Campus", class_.campus);
                    cmd.Parameters.AddWithValue("@Day", class_.day);
                    cmd.Parameters.AddWithValue("@StartTime", class_.startTime);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                    HomeView home = new HomeView();
                Body.setBody(home);
            }
        }
    }
}
