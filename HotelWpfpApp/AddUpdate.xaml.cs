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

namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for AddUpdate.xaml
    /// </summary>
    public partial class AddUpdate : Page
    {
        public AddUpdate()
        {
            InitializeComponent();
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Booking());
        }
    }
}
