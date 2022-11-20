using Microsoft.AspNetCore.Mvc;
using goglobe_API.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using goglobe_API.Data.Entities;
using goglobe_API.Data.DTOs.TravelOffers;
using System.Linq;
using AutoMapper;
using System;
using goglobe_API.Data.DTOs.Bookings;
using Microsoft.AspNetCore.Authorization;
using goglobe_API.Auth.Model;

namespace goglobe_API.Controllers
{
    [ApiController]
    [Route("/api/travelOffers")]
    public class TravelOfferController : ControllerBase
    {
        private readonly ITravelOfferRepository _travelOfferRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public TravelOfferController(ITravelOfferRepository travelOfferRepository, IMapper mapper, IBookingRepository bookingRepository)
        {
            _travelOfferRepository = travelOfferRepository;
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TravelOfferDTO>> GetAll()
        {
            return (await _travelOfferRepository.GetAll())
                .Select(obj => _mapper.Map<TravelOfferDTO>(obj));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TravelOfferDTO>> Get(int id)
        {
            var travelOffer = await _travelOfferRepository.Get(id);
            if (travelOffer == null) return NotFound($"Travel offer with id `{id}` was not found");

            return Ok(_mapper.Map<TravelOfferDTO>(travelOffer));
        }

        [HttpGet("filter")]
        public async Task<IEnumerable<TravelOfferDTO>> Filter([FromQuery] string? destination = null, [FromQuery] DateTime? dateFrom = null, [FromQuery] DateTime? dateTo = null,
                                                                    [FromQuery] int? minPrice = 0, [FromQuery] int? maxPrice = Int32.MaxValue)
        {
            var departureDate = dateFrom ?? DateTime.MinValue;
            var returnDate = dateTo ?? DateTime.MaxValue;

            return (await _travelOfferRepository.Filter(departureDate, returnDate, minPrice, maxPrice, destination))
                .Select(obj => _mapper.Map<TravelOfferDTO>(obj));
        }

        [HttpGet("{id}/bookings")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetTravelOfferBookings(int id)
        {
            var travelOffer = await _travelOfferRepository.Get(id);
            if (travelOffer == null) return NotFound($"Travel offer with id `{id}` was not found");

            return Ok((await _bookingRepository.GetTravelOfferBookings(id)).Select(obj => _mapper.Map<BookingDTO>(obj)));
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<TravelOfferDTO>> Post(CreateTravelOfferDTO createTravelOfferDTO)
        {
            var travelOffer = _mapper.Map<TravelOffer>(createTravelOfferDTO);
            
            try
            {
                await _travelOfferRepository.Create(travelOffer);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }
            

            return Created($"/api/travelOffers.{travelOffer.Id}", _mapper.Map<TravelOfferDTO>(travelOffer));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<TravelOfferDTO>> Put(int id, UpdateTravelOfferDTO updateTravelOfferDTO)
        {
            var travelOffer = await _travelOfferRepository.Get(id);
            if (travelOffer == null) return NotFound($"TravelOffer with id `{id}` was not found");
            travelOffer = MapTravelOffers(updateTravelOfferDTO, travelOffer);

            try
            {
                await _travelOfferRepository.Put(travelOffer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }

            return Ok(_mapper.Map<TravelOfferDTO>(travelOffer));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<TravelOfferDTO>> Delete(int id)
        {
            var travelOffer = await _travelOfferRepository.Get(id);
            if (travelOffer == null) return NotFound($"TravelOffer with id `{id}` was not found");

            await _travelOfferRepository.Delete(travelOffer);

            return NoContent();
        }

        private static TravelOffer MapTravelOffers(UpdateTravelOfferDTO updateTravelOfferDTO, TravelOffer travelOffer)
        {
            if (updateTravelOfferDTO.Price != 0) travelOffer.Price = updateTravelOfferDTO.Price;
            if (updateTravelOfferDTO.DepartureDate != default(DateTime)) travelOffer.DepartureDate = updateTravelOfferDTO.DepartureDate;
            if (updateTravelOfferDTO.ReturnDate != default(DateTime)) travelOffer.ReturnDate = updateTravelOfferDTO.ReturnDate;
            if (updateTravelOfferDTO.PersonCount != 0) travelOffer.PersonCount = updateTravelOfferDTO.PersonCount;
            if (updateTravelOfferDTO.Description != null) travelOffer.Description = updateTravelOfferDTO.Description;
            if (updateTravelOfferDTO.AgencyId != 0) travelOffer.AgencyId = updateTravelOfferDTO.AgencyId;
            if (updateTravelOfferDTO.HotelId != 0) travelOffer.HotelId = updateTravelOfferDTO.HotelId;
            if (updateTravelOfferDTO.CountryId != 0) travelOffer.CountryId = updateTravelOfferDTO.CountryId;
            if (updateTravelOfferDTO.CityId != 0) travelOffer.CityId = updateTravelOfferDTO.CityId;

            return travelOffer;
        }
    }
}
