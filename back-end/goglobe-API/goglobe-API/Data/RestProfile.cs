using AutoMapper;
using goglobe_API.Data.DTOs.Agencies;
using goglobe_API.Data.DTOs.TravelOffers;
using goglobe_API.Data.DTOs.Bookings;
using goglobe_API.Data.Entities;

namespace goglobe_API.Data
{
    public class RestProfile: Profile
    {
        public RestProfile()
        {
            CreateMap<Agency, AgencyDTO>();
            CreateMap<CreateAgencyDTO, Agency>();
            CreateMap<UpdateAgencyDTO, Agency>().ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
            CreateMap<TravelOffer, TravelOfferDTO>();
            CreateMap<CreateTravelOfferDTO, TravelOffer>();
            CreateMap<UpdateTravelOfferDTO, TravelOffer>().ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
            CreateMap<Booking, BookingDTO>();
            CreateMap<CreateBookingDTO, Booking>();
            CreateMap<UpdateBookingDTO, Booking>();
        }
    }
}
