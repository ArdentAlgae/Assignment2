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
    /// Interaction logic for EditClassView.xaml
    /// </summary>
    public partial class EditClassView : UserControl
    {
        Class class_;
        public EditClassView(Class class_)
        {
            this.class_ = class_;
            InitializeComponent();

            unitCodeTextBox.Text = class_.unitCode;
            campusTextBox.Text = class_.campus;
            dayTextBox.Text = class_.day;
            startTimeTextBox.Text = class_.startTime.ToString();
            endTimeTextBox.Text = class_.endTime.ToString();
            typeTextBox.Text = class_.type;
            roomTextBox.Text = class_.room;
            staffTextBox.Text = class_.staff.ToString();
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Save class?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Class newClass = new Class();
                newClass.unitCode = unitCodeTextBox.Text;
                newClass.campus = campusTextBox.Text;
                newClass.day = dayTextBox.Text;
                newClass.startTime = TimeSpan.Parse(startTimeTextBox.Text);
                newClass.endTime = TimeSpan.Parse(endTimeTextBox.Text);
                newClass.type = typeTextBox.Text;
                newClass.room = roomTextBox.Text;
                newClass.staff = Int32.Parse(staffTextBox.Text);
                using(var conn = new MySqlConnection("Database=hris;Data Source=alacritas.cis.utas.edu.au;User Id=kit206g2a;Password=group2a"))
                {
                    conn.Open();
                    MySqlCommand cmd;
                    if (class_.unitCode == null && class_.campus == null && class_.day == null && class_.startTime.Equals(new TimeSpan()))
                    {
                        cmd = new MySqlCommand("INSERT INTO class" +
                            " (unit_code," +
                            " campus," +
                            " day," +
                            " start," +
                            " end," +
                            " type," +
                            " room," +
                            " staff)" +
                            " VALUES" +
                            " (@NewUnitCode," +
                            " @NewCampus," +
                            " @NewDay," +
                            " @NewStartTime," +
                            " @NewEndTime," +
                            " @NewType," +
                            " @NewRoom," +
                            " @NewStaff)", conn);
                    }
                    else
                    {
                        cmd = new MySqlCommand("UPDATE class" +
                            " SET unit_code=@NewUnitCode," +
                            " campus=@NewCampus," +
                            " day=@NewDay," +
                            " start=@NewStartTime," +
                            " end=@NewEndTime," +
                            " type=@NewType," +
                            " room=@NewRoom," +
                            " staff=@NewStaff" +
                            " WHERE unit_code=@UnitCode" +
                            " AND campus=@Campus" +
                            " AND day=@Day" +
                            " AND start=@StartTime", conn);

                        cmd.Parameters.AddWithValue("@UnitCode", class_.unitCode);
                        cmd.Parameters.AddWithValue("@Campus", class_.campus);
                        cmd.Parameters.AddWithValue("@Day", class_.day);
                        cmd.Parameters.AddWithValue("@StartTime", class_.startTime);
                    }

                    cmd.Parameters.AddWithValue("@NewUnitCode", newClass.unitCode);
                    cmd.Parameters.AddWithValue("@NewCampus", newClass.campus);
                    cmd.Parameters.AddWithValue("@NewDay", newClass.day);
                    cmd.Parameters.AddWithValue("@NewStartTime", newClass.startTime);
                    cmd.Parameters.AddWithValue("@NewEndTime", newClass.endTime);
                    cmd.Parameters.AddWithValue("@NewType", newClass.type);
                    cmd.Parameters.AddWithValue("@NewRoom", newClass.room);
                    cmd.Parameters.AddWithValue("@NewStaff", newClass.staff);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                ClassView view = new ClassView(newClass);
                Body.setBody(view);
            }
        }

        private void DiscardButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Discard changes?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (class_.unitCode == null && class_.campus == null && class_.day == null && class_.startTime.Equals(new TimeSpan()))
                {
                    HomeView home = new HomeView();
                    Body.setBody(home);
                }
                else
                {
                    ClassView view = new ClassView(class_);
                    Body.setBody(view);
                }
            }
        }

        private bool sameClass(Class class_, DataRow row)
        {
            bool isTrue = true;
            if(class_.unitCode.Equals(row["unit_code"]))
            {
                isTrue = false;
            }
            else if (class_.campus.Equals(row["campus"]))
            {
                isTrue = false;
            }
            else if (class_.day.Equals(row["day"]))
            {
                isTrue = false;
            }
            else if (class_.startTime.Equals(row["start"]))
            {
                isTrue = false;
            }
            else if (class_.endTime.Equals(row["end"]))
            {
                isTrue = false;
            }
            else if (class_.type.Equals(row["type"]))
            {
                isTrue = false;
            }
            else if (class_.room.Equals(row["room"]))
            {
                isTrue = false;
            }
            else if (class_.staff.Equals(row["staff"]))
            {
                isTrue = false;
            }
            return isTrue;
        }

    }
}
