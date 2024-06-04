
using Repositories;
using Repositories.Entities;

namespace Services
{
    public class RoomTypeServices
    {
        private readonly RoomTypeRepository _roomTypeRepository;
        public RoomTypeServices (RoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            return await _roomTypeRepository.GetRoomTypes();
        }
    }
}
