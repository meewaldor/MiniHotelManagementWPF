using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface IRoomInformationRepository
    {
        Task<IEnumerable<RoomInformation>> GetRoomInformations();
        RoomInformation GetRoomInformationById(int id);
        Task<IEnumerable<RoomInformation>> GetRoomInformationsBySearchValue(string searchValue);
        bool AddRoomInformation(RoomInformation roomInformation);
        bool UpdateRoomInformation(RoomInformation roomInformation);
        bool DeleteRoomInformation(RoomInformation roomInformation);

    }
}
