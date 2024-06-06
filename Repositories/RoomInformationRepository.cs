

using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class RoomInformationRepository : IRoomInformationRepository
    {

        private readonly FuminiHotelManagementContext _context;
        public RoomInformationRepository (FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomInformation>> GetRoomInformations ()
        {
            return await _context.RoomInformations
                .Include(r => r.RoomType)
                .ToListAsync();
        }

        public RoomInformation GetRoomInformationById (int id)
        {
            return _context.RoomInformations
                .Include(r => r.RoomType)
                .FirstOrDefault(r => r.RoomId == id);
        }
        public bool AddRoomInformation (RoomInformation roomInformation)
        {
            _context.Add(roomInformation);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateRoomInformation (RoomInformation roomInformation)
        {;
            _context.Update(roomInformation);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteRoomInformation (RoomInformation roomInformation) 
        {
            _context.Remove(roomInformation);
            return _context.SaveChanges() > 0;
        }

        public async Task<IEnumerable<RoomInformation>> GetRoomInformationsBySearchValue(string searchValue)
        {
            return await _context.RoomInformations
                .Where(r => r.RoomNumber.Contains(searchValue) || r.RoomType.RoomTypeName.Contains(searchValue))
                .ToListAsync();
        }
    }
}
