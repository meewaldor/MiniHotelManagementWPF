using AutoMapper;
using Repositories.Entities;
using Services.Dtos;


namespace Repositories
{
    public class BookingDetailService
    {
        private readonly BookingDetailRepository _bookingDetailRepository;
        private readonly IMapper _mapper;

        public BookingDetailService(BookingDetailRepository bookingDetailRepository, IMapper mapper)
        {
            _bookingDetailRepository = bookingDetailRepository;
            _mapper = mapper;
        }
        //public async Task<IEnumerable<BookingDetailDTO>> GetAllBookingDetails()
        //{
        //    var bookingDetails = await _bookingDetailRepository.GetAllBookingDetails();

        //    var data = _mapper.Map<IEnumerable<BookingDetail>, IEnumerable<BookingDetailDTO>>(bookingDetails);

        //    return data;
        //}

        public bool AddBooking(BookingDetail bookingDetail)
        {
            return _bookingDetailRepository.AddBookingDetail(bookingDetail);
        }

        public bool UpdateBooking(BookingDetail bookingDetail)
        {
            return _bookingDetailRepository.UpdateBookingDetail(bookingDetail);
        }
        public bool DeleteBooking(BookingDetail bookingDetail)
        {
            return _bookingDetailRepository.DeleteBookingDetail(bookingDetail);
        }

        public async Task<IEnumerable<BookingDetail>> GetBookingDetailsByCustomerId(int customerId)
        {
            return await _bookingDetailRepository.GetBookingDetailsByBookingId(customerId);
        }
    }
}

