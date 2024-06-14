
using Repositories;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Services
{
    public class RoomTypeServices
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        public RoomTypeServices (IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            return await _roomTypeRepository.GetRoomTypes();
        }
    }
}
