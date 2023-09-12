using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPFappsFromColledge
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public struct Person { 
            public string name;
            public DateTime bd;
            public string gender;
            public string moreInfo;
        };


        Person[] pers  = new Person[1];
        int index = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Write_Click(object sender, RoutedEventArgs e)
        {
            string dop = " ";
            string Path = "D:\\MyDataBaseFile.txt";
            
            if (chbKind.IsChecked == true)
            {
                dop += (chbKind.Content) + "; ";
            }
            if (chbrRsponsive.IsChecked == true)
            {
                dop += (chbrRsponsive.Content) + "; ";
            }
            if (chbModest.IsChecked == true)
            {
                dop += (chbModest.Content) + "; ";
            }
       

            using ( BinaryWriter bw = new BinaryWriter(File.Open(Path, FileMode.Append)))
            {
                char spacebar = '\n';
                bw.Write(textName.Text);
                bw.Write(dtpBd.SelectedDate.ToString());
                bw.Write( (lstGender.SelectedItem as ListBoxItem).Content.ToString() );
                bw.Write(dop);
                bw.Close();
            }


        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            string Path = "D:\\MyDataBaseFile.txt";

            using (BinaryReader br = new BinaryReader(File.OpenRead(Path) ) )
            {
                int i = 0;
                while(br.PeekChar() > -1)
                {
                    pers[i].name = br.ReadString();
                    pers[i].bd =  DateTime.Parse(br.ReadString());
                    pers[i].gender = br.ReadString();
                    pers[i].moreInfo = br.ReadString();
                    i++;
                    Array.Resize(ref pers, pers.Length+1);
                }
                //string textName = br.ReadString();
                br.Close();
            }


        }

        private void nextPerson_Click(object sender, RoutedEventArgs e)
        {
            txtBlcName.Text = pers[index].name;
            txtBlcBd.Text = pers[index].bd.ToString();
            txtBlcGender.Text = pers[index].gender;
            txtBlcDopInfo.Text = pers[index].moreInfo;
            index++;
        }
    }
}
