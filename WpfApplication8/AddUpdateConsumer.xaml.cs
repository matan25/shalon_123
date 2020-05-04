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
    /// Interaction logic for AddUpdateConsumer.xaml
    /// </summary>
    public partial class AddUpdateConsumer : Window
    {
        public AddUpdateConsumer()
        {
            InitializeComponent();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            AddConsumer ac = new WpfApplication8.AddConsumer();
            this.Close();
            ac.ShowDialog();
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            UpdateConsumerTable uct = new UpdateConsumerTable();
            this.Close();
            uct.ShowDialog();
        }
    }
}
