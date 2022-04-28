﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            gridList.ItemsSource = getStaff();
        }

        List<Unit> getUnits()
        {
            List<Unit> units = new List<Unit>();
            units.Add(new Unit() {
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
            if(sender.Equals(staffButton))
            {
                gridList.ItemsSource = getStaff();
                gridList.Items.Refresh();
            }
            else if(sender.Equals(unitButton))
            {
                gridList.ItemsSource = getUnits();
                gridList.Items.Refresh();
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
    }

    public class Unit
    {
        public int unitNum { get; set; }
        public string unitName { get; set; }
        public Unit()
        {
            
        }
    }

    public class Staff
    {
        public int staffNum { get; set; }
        public string staffName { get; set; }
        public Staff()
        {

        }
    }
}