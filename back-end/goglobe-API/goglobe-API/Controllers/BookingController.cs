using Microsoft.AspNetCore.Mvc;
using goglobe_API.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using goglobe_API.Data.Entities;
using System.Linq;
using AutoMapper;
using goglobe_API.Data.DTOs.Bookings;
using System.Text;
using System;

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

        [HttpGet("referenceNumber/{referenceNumber}")]
        public async Task<ActionResult<BookingDTO>> GetByBookingReference(string referenceNumber)
        {
            var booking = await _bookingRepository.GetByBookingReference(referenceNumber);
            if (booking == null) return NotFound($"Booking with id `{referenceNumber}` was not found");

            return Ok(_mapper.Map<BookingDTO>(booking));
        }

        [HttpPost]
        public async Task<ActionResult<BookingDTO>> Post(CreateBookingDTO createBookingDTO)
        {
            var booking = _mapper.Map<Booking>(createBookingDTO);
            bool isBookingReference = true;

            while(isBookingReference)
            {
                string bookingReference = GenerateReference();
                var tempBooking = await _bookingRepository.GetByBookingReference(bookingReference);

                if(tempBooking == null)
                {
                    isBookingReference = false;
                    booking.BookingReference = bookingReference;
                }
            }

            try
            {
                await _bookingRepository.Create(booking);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }

            return Created($"/api/bookings.{booking.Id}", _mapper.Map<BookingDTO>(booking));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookingDTO>> Put(int id, UpdateBookingDTO updateTravelOfferDTO)
        {
            var booking = await _bookingRepository.Get(id);
            if (booking == null) return NotFound($"Booking with id `{id}` was not found");
            booking = MapBooking(updateTravelOfferDTO, booking); 

            try
            {
                if((int)updateTravelOfferDTO.Status < 1 || (int)updateTravelOfferDTO.Status > 3)
                {
                    throw new Exception();
                }

                booking.Status = updateTravelOfferDTO.Status;
                await _bookingRepository.Put(booking);
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }
            

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

        private static string GenerateReference()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList().ForEach(e => builder.Append(e));

            string id = builder.ToString();

            return id;
        }

        private static Booking MapBooking(UpdateBookingDTO updateBookingDTO, Booking booking)
        {
            if(updateBookingDTO.ClientId != 0)
            {
                booking.ClientId = updateBookingDTO.ClientId;
            }

            if(updateBookingDTO.TravelOfferId != 0)
            {
                booking.TravelOfferId = updateBookingDTO.TravelOfferId;
            }

            return booking;
        }
    }
}
