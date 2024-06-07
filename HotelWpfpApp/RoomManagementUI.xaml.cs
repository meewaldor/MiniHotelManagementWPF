using Repositories.Entities;
using Services;
using Services.Dtos;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for RoomManagementUI.xaml
    /// </summary>
    public partial class RoomManagementUI : Page
    {
        private readonly RoomInformationService _roomInformationService;
        private readonly RoomTypeServices _roomTypeServices;
        private RoomInformationDTO _selected;

        public RoomManagementUI(RoomInformationService roomInformationService, RoomTypeServices roomTypeServices)
        {
            _roomInformationService = roomInformationService;
            _roomTypeServices = roomTypeServices;
            InitializeComponent();
        }


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await FillDataGridView();
        }

        private async Task FillDataGridView()
        {
            //dgvRoomsList.ItemsSource = null;
            dgvRoomsList.ItemsSource = await _roomInformationService.GetAllRoomInformations();

            // Load room type to combox
            cbRoomType.ItemsSource = await _roomTypeServices.GetAllRoomTypes();
            cbRoomType.DisplayMemberPath = "RoomTypeName";
            cbRoomType.SelectedValuePath = "RoomTypeId";
            cbRoomType.SelectedIndex = 0;
            
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchValue = txtSearch.Text;

            dgvRoomsList.ItemsSource = await _roomInformationService.GetRoomInformationsBySearchValue(searchValue);
        }

        private void dgvRoomsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvRoomsList.SelectedItems.Count > 0)
            {
                _selected = (RoomInformationDTO)dgvRoomsList.SelectedItems[0];
            }           
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var roomNumber = txtRoomNumber.Text;
            var description = txtDescription.Text;
            var maxCapacity = txtCapacity.Text;
            var pricePerDay = txtPrice.Text;
            var roomTypeId = cbRoomType.SelectedValue;
            
            RoomInformation roomInformation = new RoomInformation 
            { 
                RoomNumber = roomNumber,RoomDetailDescription = description,
                RoomMaxCapacity = Convert.ToInt32(maxCapacity),
                RoomTypeId = Convert.ToInt32(roomTypeId),
                RoomStatus = 1,
                RoomPricePerDay = Convert.ToDecimal(pricePerDay)
            };    
            
            if(_roomInformationService.AddRoomInformation(roomInformation))
                MessageBox.Show("Successully Added!");
            else
                MessageBox.Show("Fail to add!");

            await FillDataGridView();
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Please select a certain room to delete!");
            }
            else
            {
                var roomId = txtRoomId.Text;
                var roomNumber = txtRoomNumber.Text;
                var description = txtDescription.Text;
                var maxCapacity = txtCapacity.Text;
                var pricePerDay = txtPrice.Text;
                var roomTypeId = cbRoomType.SelectedValue;

                RoomInformation roomInformation = new RoomInformation
                {
                    RoomId = Convert.ToInt32(roomId),
                    RoomNumber = roomNumber,
                    RoomDetailDescription = description,
                    RoomMaxCapacity = Convert.ToInt32(maxCapacity),
                    RoomTypeId = Convert.ToInt32(roomTypeId),
                    RoomStatus = 1,
                    RoomPricePerDay = Convert.ToDecimal(pricePerDay)
                };

                if (_roomInformationService.UpdateRoomInformation(roomInformation))
                {
                    MessageBox.Show("Successfully Updated!");
                    await FillDataGridView();
                }                   
                else
                    MessageBox.Show("Fail to update!");               
            }           
        }

        private void txtRoomNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Please select a certain room to delete!");
            }
            else
            {
                if (_roomInformationService.DeleteRoomInformation(_selected))
                {
                    MessageBox.Show("Successfully Deleted!");
                    await FillDataGridView();
                }                    
                else
                    MessageBox.Show("Fail to delete!");
            }          
        }
    }
}
