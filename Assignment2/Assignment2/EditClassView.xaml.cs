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
                newClass.startTime = Int32.Parse(startTimeTextBox.Text);
                newClass.endTime = Int32.Parse(endTimeTextBox.Text);
                newClass.type = typeTextBox.Text;
                newClass.room = roomTextBox.Text;
                newClass.staff = Int32.Parse(staffTextBox.Text);
                using(var conn = new MySqlConnection("connectionString"))
                {
                    conn.Open();
                    var sql = "INSERT INTO class((unit_code, campus, day, start, end, type, room, staff) VALUES(@unitCode @campus @day @startTime @endTime @type @room @staff)";
                    using(var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@unitCode", newClass.unitCode);
                        cmd.Parameters.AddWithValue("@campus", newClass.campus);
                        cmd.Parameters.AddWithValue("@day", newClass.day);
                        cmd.Parameters.AddWithValue("@startTime", newClass.startTime);
                        cmd.Parameters.AddWithValue("@endTime", newClass.endTime);
                        cmd.Parameters.AddWithValue("@type", newClass.type);
                        cmd.Parameters.AddWithValue("@room", newClass.room);
                        cmd.Parameters.AddWithValue("@staff", newClass.staff);
                    }
                }

                ClassView view = new ClassView(newClass);
                Body.setBody(view);
            }
        }

        private void DiscardButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Discard changes?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ClassView view = new ClassView(class_);
                Body.setBody(view);
            }
        }
    }
}
