using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        // Using Singleton Pattern
        private static RoomTypeRepository instance = null;
        private static readonly object instanceLock = new object();
        private RoomTypeRepository() { }
        public static RoomTypeRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomTypeRepository();
                    }
                    return instance;
                }
            }
        }

        private FuminiHotelManagementContext _context;

        public async Task<IEnumerable<RoomType>> GetRoomTypes()
        {
            _context = new();
            return await _context.RoomTypes.ToListAsync();
        }
    }
}
