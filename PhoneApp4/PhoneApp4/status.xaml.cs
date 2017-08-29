using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;

namespace PhoneApp4
{
    public partial class status : PhoneApplicationPage
    {
        public status()
        {
            InitializeComponent();
        }

        private async void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            string s =  this.ReadFileContentsAsync("status.txt");
            statusText.Text = s;

        }

        public string ReadFileContentsAsync(string fileName)
        {
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                //var file = await folder.OpenStreamForReadAsync(fileName);
                using(StreamReader sr = File.OpenText(Path.Combine(folder.Path, fileName)))
                {
                    return sr.ReadToEnd();
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                return string.Empty;
            }
        }
    }
}