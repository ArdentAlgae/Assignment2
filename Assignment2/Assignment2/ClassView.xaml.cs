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
            startTimeText.Text = class_.startTime;
            endTimeText.Text = class_.endTime;
            typeText.Text = class_.type;
            roomText.Text = class_.room;
            staffText.Text = class_.staff;
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
                DatabaseController.deleteClass(class_);
                HomeView home = new HomeView();
                Body.setBody(home);
            }
        }
    }
}
