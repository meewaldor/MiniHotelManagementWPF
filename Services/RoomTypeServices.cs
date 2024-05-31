
using Repositories;
using Repositories.Entities;

namespace Services
{
    public class RoomTypeServices
    {
        public List<RoomType> GetAllRoomTypes()
        {
            return RoomTypeRepository.Instance.GetRoomTypes();
        }
    }
}
