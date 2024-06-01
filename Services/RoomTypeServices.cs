
using Repositories;
using Repositories.Entities;

namespace Services
{
    public class RoomTypeServices
    {
        public async Task<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            return await RoomTypeRepository.Instance.GetRoomTypes();
        }
    }
}
