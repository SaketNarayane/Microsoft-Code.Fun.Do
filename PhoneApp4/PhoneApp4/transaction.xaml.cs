using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using Windows.Storage;
using System.Threading.Tasks;
using System.Text;

namespace PhoneApp4
{
    /*
     public class data
    {
        public String date;
        int amount;
        public string exp;
    }


    public static void WriteXML()
    {
        data overview = new data();
        overview.date = datefield;

         overview.amount = amountfield;
         overview.exp = expfield;
        System.Xml.Serialization.XmlSerializer writer = 
            new System.Xml.Serialization.XmlSerializer(typeof(data));

        System.IO.StreamWriter file = new System.IO.StreamWriter(
            "SerializationOverview.xml");
        writer.Serialize(file, overview);
        file.Close();
    }
     **/

    public partial class transaction : PhoneApplicationPage
    {
        static void Main(string[] args)
        {
            // WriteXML();
        }
        static int balance = 0;
        int amt;
        public transaction()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e) //expenditure
        {
            /* public class XMLWrite
            {

            } */
            string d = datefield.Text;
            //string thetext=d.Text;
            MessageBox.Show("On the date " + d);
            // int amt;
            amt = Convert.ToInt32(amountfield.Text);
            amt = int.Parse(amountfield.Text);
            balance = balance - amt;
            string s = balance.ToString();
            MessageBox.Show("your balance is " + s);

            string input = d + "," + (amt * -1).ToString() + "," + balance.ToString();
            await this.WriteDataToFileAsync("status.txt", input);

            //           INSERT INTO Table[(date[,amount])] VALUES ( d[,amt]);
        }

        public async Task WriteDataToFileAsync(string fileName, string content)
        {
            byte[] data = Encoding.Unicode.GetBytes(content);

            var folder = ApplicationData.Current.LocalFolder;

            var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            using (StreamWriter sw = File.CreateText(Path.Combine(folder.Path, fileName)))
            {
                sw.WriteLine(content);
            }

            //using (var s = await file.OpenStreamForWriteAsync())
            //{
            //    await s.WriteAsync(data, 0, data.Length);
            //}
        }

        public async Task<string> ReadFileContentsAsync(string fileName)
        {
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync(fileName);

                using (var streamReader = new StreamReader(file))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                return string.Empty;
            }
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e) //credit
        {   
           /* public class XMLWrite
           {

           } */
            string d =datefield.Text;
            //string thetext=d.Text;
            MessageBox.Show("On the date "+d);
           // int amt;
            amt = Convert.ToInt32(amountfield.Text);
            amt = int.Parse(amountfield.Text);
            balance = balance + amt;
            string s = balance.ToString();
            MessageBox.Show("your balance is "+s);

            string input = d + "," + (amt).ToString() + "," + balance.ToString();
            await this.WriteDataToFileAsync("status.txt", input);
           

/*$query="INSERT INTO dbo.Table.sql (date,amount) 
             VALUES(d,amt) ";
               //  $result=mysql_query($query);
           // $redirectUrl = 'index.php';
		echo '<script type="application/javascript">alert(" Creditted !"); window.location.href = "'.$redirectUrl.'";</script>';
		exit;*/
            
  //          INSERT INTO Table[(date[,amount])] VALUES ( d[,amt]);
            

        }
        
    }
}