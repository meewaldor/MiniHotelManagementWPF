

using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        private static RoomInformationRepository instance = null;
        private static readonly object instanceLock = new object();
        private RoomInformationRepository() { }
        public static RoomInformationRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomInformationRepository();
                    }
                    return instance;
                }
            }
        }

        private FuminiHotelManagementContext _context;

        public async Task<IEnumerable<RoomInformation>> GetRoomInformations ()
        {
            _context = new();
            return await _context.RoomInformations.ToListAsync();
        }

        public RoomInformation GetRoomInformationById (int id)
        {
            _context = new();
            return _context.RoomInformations.Find(id);
        }
        public bool AddRoomInformation (RoomInformation roomInformation)
        {
            _context = new();
            _context.Add(roomInformation);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateRoomInformation (RoomInformation roomInformation)
        {
            _context = new();
            _context.Update(roomInformation);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteRoomInformation (RoomInformation roomInformation) 
        {
            _context = new();
            _context.Remove(roomInformation);
            return _context.SaveChanges() > 0;
        }

        public async Task<IEnumerable<RoomInformation>> GetRoomInformationsByType(int roomTypeId)
        {
            _context = new();
            return await _context.RoomInformations
                .Where(r => r.RoomTypeId == roomTypeId)
                .ToListAsync();
        }
    }
}
