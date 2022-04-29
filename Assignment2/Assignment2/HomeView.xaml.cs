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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        char typeSelected = 's';
        public HomeView()
        {
            InitializeComponent();

            gridList.ItemsSource = getStaff();
        }

        List<Unit> getUnits()
        {
            List<Unit> units = new List<Unit>();
            units.Add(new Unit()
            {
                unitNum = 1,
                unitName = "Jeff",
            });
            units.Add(new Unit()
            {
                unitNum = 2,
                unitName = "Geoff",
            });
            return units;
        }

        List<Staff> getStaff()
        {
            List<Staff> units = new List<Staff>();
            units.Add(new Staff()
            {
                staffNum = 3,
                staffName = "Frank",
            });
            units.Add(new Staff()
            {
                staffNum = 4,
                staffName = "Craig",
            });
            return units;
        }

        private void click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(staffButton))
            {
                gridList.ItemsSource = getStaff();
                gridList.Items.Refresh();
                typeSelected = 's';
            }
            else if (sender.Equals(unitButton))
            {
                gridList.ItemsSource = getUnits();
                gridList.Items.Refresh();
                typeSelected = 'u';
            }
            /*else if (sender.Equals(classButton))
            {
                gridList.ItemsSource = getClasses();
                gridList.Items.Refresh();
            }
            else if (sender.Equals(consultationButton))
            {
                gridList.ItemsSource = getConsultations();
                gridList.Items.Refresh();
            }*/
        }



        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(e.AddedItems[0]);
                if (typeSelected == 'u')
                {
                    List<Unit> unitList = (List<Unit>)gridList.ItemsSource;
                    AddUnitView view = new AddUnitView(unitList[row.GetIndex()]);
                    Body.setBody(view);
                }
                else if (typeSelected == 's')
                {
                    List<Staff> staffList = (List<Staff>)gridList.ItemsSource;
                    AddStaffView view = new AddStaffView(staffList[row.GetIndex()]);
                    Body.setBody(view);
                }
                else if (typeSelected == 'c')
                {
                    List<Class> classList = (List<Class>)gridList.ItemsSource;
                    AddStaffView view = new AddStaffView(classList[row.GetIndex()]);
                    Body.setBody(view);
                }
                else if (typeSelected == 'o')
                {
                    List<Consultation> consultationList = (List<Consultation>)gridList.ItemsSource;
                    AddStaffView view = new AddStaffView(consultationList[row.GetIndex()]);
                    Body.setBody(view);
                }
            }

        }

        private void AddUnit_Click(object sender, RoutedEventArgs e)
        {
            AddUnitView view = new AddUnitView(new Unit());
            Body.setBody(view);
        }
    }
}
