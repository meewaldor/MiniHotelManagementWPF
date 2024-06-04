using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {

        private readonly FuminiHotelManagementContext _context;

        public RoomTypeRepository (FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomType>> GetRoomTypes()
        {
            return await _context.RoomTypes.ToListAsync();
        }
    }
}
