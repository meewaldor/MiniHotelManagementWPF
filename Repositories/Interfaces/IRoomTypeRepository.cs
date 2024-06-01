using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface IRoomTypeRepository
    {
        Task<IEnumerable<RoomType>> GetRoomTypes();
    }
}
