using AutoMapper;
using Repositories;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Dtos;

namespace Services
{
    public class RoomInformationService
    {
        private readonly IRoomInformationRepository _roomInformationRepository;
        private readonly IMapper _mapper;
        public RoomInformationService (IRoomInformationRepository roomInformationRepository, IMapper mapper)
        {
            _roomInformationRepository = roomInformationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomInformationDTO>> GetAllRoomInformations()
        {
            var roomInfomations = await _roomInformationRepository.GetRoomInformations();

            var data = _mapper.Map<IEnumerable<RoomInformation>, IEnumerable<RoomInformationDTO>>(roomInfomations);

            return data;
        }

        public RoomInformationDTO GetRoomInformationById(int roomId)
        {
            var roomInfomations = _roomInformationRepository.GetRoomInformationById(roomId);

            var data = _mapper.Map<RoomInformation, RoomInformationDTO>(roomInfomations);

            return data;
        }

        public async Task<IEnumerable<RoomInformationDTO>> GetRoomInformationsBySearchValue(string searchValue)
        {
            var roomInfomations = await _roomInformationRepository.GetRoomInformationsBySearchValue(searchValue);

            var data = _mapper.Map<IEnumerable<RoomInformation>, IEnumerable<RoomInformationDTO>>(roomInfomations);

            return data;
        }

        public bool AddRoomInformation (RoomInformation roomInformation)
        {
            return _roomInformationRepository.AddRoomInformation (roomInformation);
        }

        public bool UpdateRoomInformation (RoomInformationDTO roomInformationDto)
        {
            RoomInformation roomInformation = _roomInformationRepository.GetRoomInformationById(roomInformationDto.RoomId);
            if (roomInformation == null) { return false; }
            _mapper.Map(roomInformationDto, roomInformation);
            return _roomInformationRepository.UpdateRoomInformation (roomInformation);
        }

        public bool DeleteRoomInformation (RoomInformationDTO roomInformationDto)
        {
            RoomInformation roomInformation = _roomInformationRepository.GetRoomInformationById(roomInformationDto.RoomId);
            if (roomInformation == null) { return false; }
            _mapper.Map(roomInformationDto, roomInformation);
            roomInformation.RoomStatus = 0;
            return _roomInformationRepository.UpdateRoomInformation (roomInformation);
        }

    }
}
