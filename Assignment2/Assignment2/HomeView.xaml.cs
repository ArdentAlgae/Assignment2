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


namespace Assignment2
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        char typeSelected = 's';
        public HomeView()
        {
            InitializeComponent();

        }

        void getUnits()
        {
            MySqlConnection conn = new MySqlConnection("Database=hris;Data Source=alacritas.cis.utas.edu.au;User Id=kit206g2a;Password=group2a");

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT code, title, coordinator from unit", conn);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("unit");
                adp.Fill(dt);
                gridList.ItemsSource = dt.DefaultView;
                adp.Update(dt);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void getStaff()
        {
            MySqlConnection conn = new MySqlConnection("Database=hris;Data Source=alacritas.cis.utas.edu.au;User Id=kit206g2a;Password=group2a");

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT id, given_name, family_name, title, campus, phone, room, email, photo, category from staff", conn);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("staff");
                adp.Fill(dt);
                gridList.ItemsSource = dt.DefaultView;
                adp.Update(dt);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void getClasses()
        {
            MySqlConnection conn = new MySqlConnection("Database=hris;Data Source=alacritas.cis.utas.edu.au;User Id=kit206g2a;Password=group2a");

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT unit_code, campus, day, start, end, type, room, staff from class", conn);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("class");
                adp.Fill(dt);
                gridList.ItemsSource = dt.DefaultView;
                adp.Update(dt);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void getConsultations()
        {
            MySqlConnection conn = new MySqlConnection("Database=hris;Data Source=alacritas.cis.utas.edu.au;User Id=kit206g2a;Password=group2a");

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT staff_id, day, start, end from consultation", conn);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("consultation");
                adp.Fill(dt);
                gridList.ItemsSource = dt.DefaultView;
                adp.Update(dt);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(staffButton))
            {
                getStaff();
                gridList.Items.Refresh();
                typeSelected = 's';
            }
            else if (sender.Equals(unitButton))
            {
                getUnits();
                gridList.Items.Refresh();
                typeSelected = 'u';
            }
            else if (sender.Equals(classButton))
            {
                getClasses();
                gridList.Items.Refresh();
                typeSelected = 'c';
            }
            else if (sender.Equals(consultationButton))
            {
                getConsultations();
                gridList.Items.Refresh();
                typeSelected = 'o';
            }
        }



        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(e.AddedItems[0]);
                DataRowView rowView = (DataRowView) e.AddedItems[0];
                object[] rowData = rowView.Row.ItemArray;
                if (typeSelected == 'u')
                {
                    AddUnitView view = new AddUnitView(new Unit(rowData));
                    Body.setBody(view);
                }
                else if (typeSelected == 's')
                {
                    StaffView view = new StaffView(new Staff(rowData));
                    Body.setBody(view);
                }
                else if (typeSelected == 'c')
                {
                    EditClassView view = new EditClassView(new Class(rowData));
                    Body.setBody(view);
                }
                else if (typeSelected == 'o')
                {
                    List<Consultation> consultationList = (List<Consultation>)gridList.ItemsSource;
                    AddConsultationView view = new AddConsultationView(consultationList[row.GetIndex()]);
                    Body.setBody(view);
                }
            }

        }

        private void NewEntry_Click(object sender, RoutedEventArgs e)
        {
            if (typeSelected == 's')
            {
                AddStaffView view = new AddStaffView(new Staff());
                Body.setBody(view);
            }
            else if (typeSelected == 'u')
            {
                AddUnitView view = new AddUnitView(new Unit(null));
                Body.setBody(view);
            }
            else if (typeSelected == 'c')
            {
                ClassView view = new ClassView(new Class());
                Body.setBody(view);
            }
            else if (typeSelected == 'o')
            {
                AddConsultationView view = new AddConsultationView(new Consultation());
                Body.setBody(view);
            }
        }
    }
}
