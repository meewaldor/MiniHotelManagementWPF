using Repositories.Entities;

namespace Repositories
{
    public class RoomTypeRepository
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

        public List<RoomType> GetRoomTypes()
        {
            _context = new();
            return _context.RoomTypes.ToList();
        }
    }
}
