using AutoMapper;
using Repositories;
using Repositories.Dtos;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Dtos;

namespace Services
{
    public class BookingService
    {
        private readonly BookingReservationRepository _bookingReservationRepository;
        private readonly IMapper _mapper;

        public BookingService(BookingReservationRepository bookingReservationRepository, IMapper mapper) 
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
        //public bool AddBooking (BookingReservation bookingReservation)
        //{
        //    return BookingReservationRepository.Instance.AddBooking (bookingReservation);
        //}

        //public bool UpdateBooking (BookingReservation bookingReservation)
        //{
        //    return BookingReservationRepository.Instance.UpdateBooking (bookingReservation);
        //}
        //public bool DeleteBooking (BookingReservation bookingReservation)
        //{
        //    return BookingReservationRepository.Instance.DeleteBooking(bookingReservation);
        //}

        //public async Task<IEnumerable<BookingReservation>> GetAllBooingReservations ()
        //{
        //    return await BookingReservationRepository.Instance.GetAllBookings();
        //}

        //public async Task<IEnumerable<BookingReservation>> GetBookingReservationsByCustomerId (int customerId)
        //{
        //    return await BookingReservationRepository.Instance.GetBookingsByCustomerId (customerId);
        //}
        //public BookingReservation GetBookingReservationById (int id)
        //{
        //    return BookingReservationRepository.Instance.GetBookingById (id);
        //}
    }
}
