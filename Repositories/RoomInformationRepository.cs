

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
                .Where(r => r.RoomStatus != 0)
                .Include(r => r.RoomType)
                .ToListAsync();
        }

        public RoomInformation GetRoomInformationById (int id)
        {
            return _context.RoomInformations
                .Where(r => r.RoomStatus != 0)
                .Include(r => r.RoomType)
                .FirstOrDefault(r => r.RoomId == id);
        }
        public bool AddRoomInformation (RoomInformation roomInformation)
        {
            _context.Add(roomInformation);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateRoomInformation (RoomInformation roomInformation)
        {
            _context.Attach(roomInformation);
            _context.Entry(roomInformation).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool DeleteRoomInformation (RoomInformation roomInformation) 
        {
            var existingRoom = _context.RoomInformations.Find(roomInformation.RoomId);
            if (existingRoom != null)
            {
                existingRoom.RoomStatus = 0;
                _context.Entry(existingRoom).CurrentValues.SetValues(existingRoom);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<RoomInformation>> GetRoomInformationsBySearchValue(string searchValue)
        {
            return await _context.RoomInformations
                .Where(r => (r.RoomNumber.Contains(searchValue) || r.RoomType.RoomTypeName.Contains(searchValue)) && r.RoomStatus !=0)
                .ToListAsync();
        }
    }
}
