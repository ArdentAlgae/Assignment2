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
    /// Interaction logic for EditUnitView.xaml
    /// </summary>
    public partial class EditUnitView : UserControl
    {
        Unit unit;
        public EditUnitView(Unit unit)
        {
            InitializeComponent();
            this.unit = unit;

            unitCodeTextBox.Text = unit.unitCode;
            unitTitleTextBox.Text = unit.unitTitle;
            unitCoordinatorTextBox.Text = unit.unitCoordinator.ToString();
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Save class?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Unit newUnit = new Unit();
                newUnit.unitCode = unitCodeTextBox.Text;
                newUnit.unitTitle = unitTitleTextBox.Text;
                newUnit.unitCoordinator = Int32.Parse(unitCoordinatorTextBox.Text);
                using(var conn = new MySqlConnection("Database=hris;Data Source=alacritas.cis.utas.edu.au;User Id=kit206g2a;Password=group2a"))
                {
                    conn.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("UPDATE unit" +
                        " SET code=@NewUnitCode," +
                        " title=@NewTitle," +
                        " coordinator=@NewCoordinator" +
                        " WHERE code=@UnitCode", conn);

                    cmd.Parameters.AddWithValue("@UnitCode", unit.unitCode);
                    cmd.Parameters.AddWithValue("@NewUnitCode", newUnit.unitCode);
                    cmd.Parameters.AddWithValue("@NewTitle", newUnit.unitTitle);
                    cmd.Parameters.AddWithValue("@NewCoordinator", newUnit.unitCoordinator);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                HomeView view = new HomeView('u');
                Body.setBody(view);
            }
        }

        private void DiscardButton_Clicked(object sender, RoutedEventArgs e)
        {
            HomeView home = new HomeView();
            Body.setBody(home);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HomeView home = new HomeView();
            Body.setBody(home);
        }
    }
}
