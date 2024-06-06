using AutoMapper;
using Repositories;
using Repositories.Dtos;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Dtos;

namespace Services
{
    public class BookingReservationService
    {
        private readonly BookingReservationRepository _bookingReservationRepository;
        private readonly IMapper _mapper;

        public BookingReservationService(BookingReservationRepository bookingReservationRepository, IMapper mapper) 
        {
            _bookingReservationRepository = bookingReservationRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookingReservationDTO>> GetAllBookingReservations()
        {
            var bookingReservations = await _bookingReservationRepository.GetAllBookings();
            
            var data = _mapper.Map< IEnumerable<BookingReservation>, IEnumerable<BookingReservationDTO>>(bookingReservations); 

            return data;
        }

        public async Task<IEnumerable<BookingReservationDTO>> SearchBookings(string searchValue)
        {
            var bookingReservations = await _bookingReservationRepository.SearchBookings(searchValue);

            var data = _mapper.Map<IEnumerable<BookingReservation>, IEnumerable<BookingReservationDTO>>(bookingReservations);

            return data;
        }

        public bool AddBooking(BookingReservation bookingReservation)
        {
            return _bookingReservationRepository.AddBooking(bookingReservation);
        }

        public bool UpdateBooking(BookingReservation bookingReservation)
        {
            return _bookingReservationRepository.UpdateBooking(bookingReservation);
        }
        public bool DeleteBooking(BookingReservation bookingReservation)
        {
            return _bookingReservationRepository.DeleteBooking(bookingReservation);
        }

        public async Task<IEnumerable<BookingReservation>> GetBookingReservationsByCustomerId(int customerId)
        {
            return await _bookingReservationRepository.GetBookingsByCustomerId(customerId);
        }
        public BookingReservation GetBookingReservationById(int id)
        {
            return _bookingReservationRepository.GetBookingById(id);
        }
    }
}
