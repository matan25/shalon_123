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
using System.Windows.Shapes;

namespace WpfApplication8
{
    /// <summary>
    /// Interaction logic for AddConsumer.xaml
    /// </summary>
    public partial class AddConsumer : Window
    {
        private ConsumerServieceBL csb = new ConsumerServieceBL();
        private Database1Entities1 db1 = new Database1Entities1();
        public AddConsumer()
        {
            InitializeComponent();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Submit(object sender, RoutedEventArgs e)
        {
                bool check = false;
                bool[] arr1 = new bool[7];
                for (int i = 0; i < arr1.Length; i++)
                {
                    arr1[i] = check;
                }
                if(Civilian_NBC_Masks.IsChecked == true)
                    arr1[0] = true;
                if(Industrial_Masks.IsChecked == true)
                    arr1[1] = true;
                if(Military_NBC_Masks.IsChecked == true)
                    arr1[2] = true;
                if(Personal_NBC_Filters.IsChecked == true)
                    arr1[3] = true;
                if(Industrial_Filters.IsChecked == true)
                    arr1[4] = true;
                if(Huto_Injectors.IsChecked == true)
                    arr1[5] = true;
                if(Collective_NBC_System.IsChecked == true)
                    arr1[6] = true;
                string[] arr2 = new string[7];
                arr2[0] = Civilian_NBC_Masks.Name;
                arr2[1] = Industrial_Masks.Name;
                arr2[2] = Military_NBC_Masks.Name;
                arr2[3] = Personal_NBC_Filters.Name;
                arr2[4] = Industrial_Filters.Name;
                arr2[5] = Huto_Injectors.Name;
                arr2[6] = Civilian_NBC_Masks.Name;
                string[] ret = csb.CheckBoxChecking(arr1,arr2);
              bool flag = csb.CheckChanges(tCompanyName.Text, tCompanyCountry.Text, cPriority.Text, ret, tNote.Text, cStatus.Text);
            if (flag == true)
            {
                db1 = csb.InsertClient(tCompanyName.Text, tCompanyCountry.Text, cPriority.Text, ret, tNote.Text, cStatus.Text, db1);
                this.db1.SaveChanges();
                this.Close();
            }

            else
            {
                MessageBox.Show("Error: you must fullfill all details/according to requirnments!");
            }
        }

        private void cnm_Checked(object sender, RoutedEventArgs e)
        {
        }
    }
}
