using Repositories;
using Repositories.Entities;

namespace Services
{
    public class RoomInformationService
    {
        public List<RoomInformation> GetAllRoomInformations()
        {
            return RoomInformationRepository.Instance.GetRoomInformations();
        }

        public RoomInformation GetRoomInformationById(int id)
        {
            return RoomInformationRepository.Instance.GetRoomInformationById(id);
        }

        public bool AddRoomInformation (RoomInformation roomInformation)
        {
            return RoomInformationRepository.Instance.AddRoomInformation (roomInformation);
        }

        public bool UpdateRoomInformation (RoomInformation roomInformation)
        {
            return RoomInformationRepository.Instance.UpdateRoomInformation (roomInformation);
        }

        public bool DeleteRoomInformation (RoomInformation roomInformation)
        {
            return RoomInformationRepository.Instance.DeleteRoomInformation (roomInformation);
        }
    }
}
