using Services;
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
    /// Interaction logic for RoomManagementUI.xaml
    /// </summary>
    public partial class RoomManagementUI : Page
    {
        RoomInformationService _roomInformationService;
        public RoomManagementUI(RoomInformationService roomInformationService)
        {
            _roomInformationService = roomInformationService;
            InitializeComponent();
            FillDataGridView();
        }

        private async void FillDataGridView()
        {
            dgvRoomsList.ItemsSource = null;
            dgvRoomsList.ItemsSource = await _roomInformationService.GetAllRoomInformations();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void grdRoomsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
