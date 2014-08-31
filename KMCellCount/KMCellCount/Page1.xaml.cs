using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Globalization;

namespace KMCellCount
{
    public partial class Page1 : PhoneApplicationPage
    {
        private Int16 total = 0;
        private Int16 dimen = 0;

        private VibrateController testVibrateController = VibrateController.Default;
        
        public Page1()
        {
            InitializeComponent();
        }

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            testVibrateController.Start(TimeSpan.FromSeconds(0.3));
            total++;
            btnCount.Content = total;

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            total = 0;
            btnCount.Content = "Press to count";
            txtDil.Text = "";
            txtField.Text = "";
            btnCount.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (total != 0)
            {
                StandardPopup.IsOpen = true;
            }
        }

        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            StandardPopup.IsOpen = false;
            btnCount.Visibility = System.Windows.Visibility.Collapsed;
            dimen = 0;
        }

        private void ClosePopup2Clicked(object sender, RoutedEventArgs e)
        {
            StandardPopup.IsOpen = false;
            btnCount.Visibility = System.Windows.Visibility.Collapsed;
            dimen = 1;
        }

        private void CalFin(object sender, RoutedEventArgs e)
        {
            if (txtDil.Text != "" && txtField.Text != "")
            {
                int CountFin = 0;
                int factor = 10;



                if (dimen == 1)
                {
                    factor = 250;
                }


                CountFin = factor * Convert.ToInt16(txtDil.Text) * (total / Convert.ToInt16(txtField.Text));

                MessageBoxResult result = MessageBox.Show(CountFin.ToString("#,#", CultureInfo.InvariantCulture) + " cell/mL", "Result:", MessageBoxButton.OK);
                
            }
        }

    }
}