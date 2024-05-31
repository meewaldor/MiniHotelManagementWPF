

using Microsoft.EntityFrameworkCore;
using Repositories.Entities;

namespace Repositories
{
    public class RoomInformationRepository
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

        public List<RoomInformation> GetRoomInformations ()
        {
            _context = new();
            return _context.RoomInformations.ToList();
        }

        public RoomInformation GetRoomInformationById (int id)
        {
            _context = new();
            return _context.RoomInformations.Find (id);
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

    }
}
