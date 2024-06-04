using Repositories;
using Repositories.Entities;

namespace Services
{
    public class RoomInformationService
    {
        private readonly RoomInformationRepository _roomInformationRepository;
        public RoomInformationService (RoomInformationRepository roomInformationRepository)
        {
            _roomInformationRepository = roomInformationRepository;
        }

        public async Task<IEnumerable<RoomInformation>> GetAllRoomInformations()
        {
            return await _roomInformationRepository.GetRoomInformations();
        }

        public RoomInformation GetRoomInformationById(int id)
        {
            return _roomInformationRepository.GetRoomInformationById(id);
        }
        public async Task<IEnumerable<RoomInformation>> GetRoomInformationsByType(int roomTypeId)
        {
            return await _roomInformationRepository.GetRoomInformationsByType(roomTypeId);
        }

        public bool AddRoomInformation (RoomInformation roomInformation)
        {
            return _roomInformationRepository.AddRoomInformation (roomInformation);
        }

        public bool UpdateRoomInformation (RoomInformation roomInformation)
        {
            return _roomInformationRepository.UpdateRoomInformation (roomInformation);
        }

        public bool DeleteRoomInformation (RoomInformation roomInformation)
        {
            return _roomInformationRepository.DeleteRoomInformation (roomInformation);
        }

    }
}
