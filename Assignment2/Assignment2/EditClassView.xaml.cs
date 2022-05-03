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
                    MySqlCommand cmd = new MySqlCommand("SELECT unit_code, campus, day, start, end, type, room, staff from class", conn);

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                    adp.UpdateCommand = new MySqlCommand("UPDATE class SET unit_code=@unit_code, campus=@campus, day=@day, start=@start, end=@end, type=@type, " +
                        "room=@room, staff=@staff WHERE unit_code=@old_unit_code, campus=@old_campus, day=@old_day, start=@old_start", conn);

                    adp.UpdateCommand.Parameters.Add("@unit_code", MySqlDbType.VarChar, 6, "unit_code");
                    adp.UpdateCommand.Parameters.Add("@campus", MySqlDbType.Enum, 2, "campus");
                    adp.UpdateCommand.Parameters.Add("@day", MySqlDbType.Enum, 7, "day");
                    adp.UpdateCommand.Parameters.Add("@start", MySqlDbType.Time, 0, "start");
                    adp.UpdateCommand.Parameters.Add("@end", MySqlDbType.Time, 0, "end");
                    adp.UpdateCommand.Parameters.Add("@type", MySqlDbType.Enum, 4, "type");
                    adp.UpdateCommand.Parameters.Add("@room", MySqlDbType.VarChar, 20, "room");
                    adp.UpdateCommand.Parameters.Add("@staff", MySqlDbType.Int32, 11, "staff");
                    adp.UpdateCommand.Parameters.Add("@old_unit_code", MySqlDbType.VarChar, 6, "unit_code").SourceVersion = DataRowVersion.Original;
                    adp.UpdateCommand.Parameters.Add("@old_campus", MySqlDbType.Enum, 2, "campus").SourceVersion = DataRowVersion.Original;
                    adp.UpdateCommand.Parameters.Add("@old_day", MySqlDbType.Enum, 7, "day").SourceVersion = DataRowVersion.Original;
                    adp.UpdateCommand.Parameters.Add("@old_start", MySqlDbType.Time, 0, "start").SourceVersion = DataRowVersion.Original;

                    DataTable dt = new DataTable("class");
                    adp.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (sameClass(class_, row))
                        {
                            row["unit_code"] = newClass.unitCode;
                            row["campus"] = newClass.campus;
                            row["day"] = newClass.day;
                            row["start"] = newClass.startTime;
                            row["end"] = newClass.endTime;
                            row["type"] = newClass.type;
                            row["room"] = newClass.room;
                            row["staff"] = newClass.staff;
                        }
                    }
                    adp.Update(dt);
                    
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
