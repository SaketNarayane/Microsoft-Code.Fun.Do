using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp4.Resources;

namespace PhoneApp4
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Navigation.Service(new Uri("/transaction.xaml"));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Navigation.Service(new Uri("/status.xaml"));
        }

    }
}