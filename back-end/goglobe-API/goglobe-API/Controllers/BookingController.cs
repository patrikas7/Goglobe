using Microsoft.AspNetCore.Mvc;
using goglobe_API.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using goglobe_API.Data.Entities;
using System.Linq;
using AutoMapper;
using goglobe_API.Data.DTOs.Bookings;

namespace goglobe_API.Controllers
{
    [ApiController]
    [Route("/api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingController(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookingDTO>> GetAll()
        {
            return (await _bookingRepository.GetAll())
                .Select(obj => _mapper.Map<BookingDTO>(obj));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> Get(int id)
        {
            var booking = await _bookingRepository.Get(id);
            if (booking == null) return NotFound($"Booking with id `{id}` was not found");

            return Ok(_mapper.Map<BookingDTO>(booking));
        }

        [HttpPost]
        public async Task<ActionResult<BookingDTO>> Post(CreateBookingDTO createBookingDTO)
        {
            var booking = _mapper.Map<Booking>(createBookingDTO);

            await _bookingRepository.Create(booking);

            return Created($"/api/bookings.{booking.Id}", _mapper.Map<BookingDTO>(booking));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookingDTO>> Put(int id, UpdateBookingDTO updateTravelOfferDTO)
        {
            var booking = await _bookingRepository.Get(id);
            if (booking == null) return NotFound($"Booking with id `{id}` was not found");

            await _bookingRepository.Put(booking);

            return Ok(_mapper.Map<BookingDTO>(booking));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingDTO>> Delete(int id)
        {
            var booking = await _bookingRepository.Get(id);
            if (booking == null) return NotFound($"Booking with id `{id}` was not found");

            await _bookingRepository.Delete(booking);

            return NoContent();
        }
    }
}
