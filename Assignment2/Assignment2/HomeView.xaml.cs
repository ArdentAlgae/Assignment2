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
                unitCode = "KMA123",
                unitName = "How to make jorts",
                unitCoordinator = 456
            });
            units.Add(new Unit()
            {
                unitCode = "KMA789",
                unitName = "How not to make jorts",
                unitCoordinator = 101112
            });
            return units;
        }

        List<Staff> getStaff()
        {
            List<Staff> units = new List<Staff>();
            units.Add(new Staff()
            {
                staffID = 456,
                givenName = "Frank",
                familyName = "Jhonson",
                title = "Prof.",
                campus = "Sandy Bay",
                phone = 1234567890,
                room = "02GHT834",
                email = "frank.jhonson@utas.edu.au"
            });
            units.Add(new Staff()
            {
                staffID = 101112,
                givenName = "Craig",
                familyName = "Phillips",
                title = "Dr",
                campus = "Launceston",
                phone = 0987654321,
                room = "03PWF175",
                email = "Craig.Phillips2@utas.edu.au"
            });
            return units;
        }

        List<Class> getClasses()
        {
            List<Class> units = new List<Class>();
            units.Add(new Class()
            {
                unitCode = "KMA123",
                campus = "Sandy Bay",
                day = "Friday"
            });
            units.Add(new Class()
            {
                unitCode = "KMA789",
                campus = "Launceston",
                day = "Thursday"
            });
            return units;
        }

        List<Consultation> getConsultations()
        {
            List<Consultation> units = new List<Consultation>();
            units.Add(new Consultation()
            {
                staffID = 456,
                day = "Monday",
                startTime = 13,
                endTime = 15
            });
            units.Add(new Consultation()
            {
                staffID = 101112,
                day = "Tuesday",
                startTime = 9,
                endTime = 11
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
            else if (sender.Equals(classButton))
            {
                gridList.ItemsSource = getClasses();
                gridList.Items.Refresh();
                typeSelected = 'c';
            }
            else if (sender.Equals(consultationButton))
            {
                gridList.ItemsSource = getConsultations();
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
                if (typeSelected == 'u')
                {
                    List<Unit> unitList = (List<Unit>)gridList.ItemsSource;
                    AddUnitView view = new AddUnitView(unitList[row.GetIndex()]);
                    Body.setBody(view);
                }
                else if (typeSelected == 's')
                {
                    List<Staff> staffList = (List<Staff>)gridList.ItemsSource;
                    EditStaffView view = new AddStaffView(staffList[row.GetIndex()]);
                    Body.setBody(view);
                }
                else if (typeSelected == 'c')
                {
                    List<Class> classList = (List<Class>)gridList.ItemsSource;
                    ClassView view = new ClassView(classList[row.GetIndex()]);
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
                AddUnitView view = new AddUnitView(new Unit());
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
