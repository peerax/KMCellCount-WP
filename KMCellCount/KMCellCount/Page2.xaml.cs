using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace KMCellCount
{
    public partial class Page2 : PhoneApplicationPage
    {
        private int TimeToCount;
        private int Counting = 0;
        private int TotalCount;
        private System.Windows.Threading.DispatcherTimer dt;

        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TotalCount++;
            btnCount.Content = TotalCount.ToString();
            if (Counting == 0)
            {
                TimeToCount = int.Parse(txtTime.Text);
                TimeToCount *= 60;
                 dt = new System.Windows.Threading.DispatcherTimer();
                dt.Interval = new TimeSpan(0, 0, 0, 0, 1000);
                dt.Tick += new EventHandler(dt_Tick);
                dt.Start();
                Counting = 1;
            }

        }
        void dt_Tick(object sender, EventArgs e)
        {
            TimeToCount--;
            txtTime.Text = TimeToCount.ToString();
            if (TimeToCount == 0)
            {

                dt.Stop();
                btnCount.IsEnabled = false;
            }
        }
    }
}