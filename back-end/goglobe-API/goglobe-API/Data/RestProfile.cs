using AutoMapper;
using goglobe_API.Data.DTOs.Agencies;
using goglobe_API.Data.Entities;

namespace goglobe_API.Data
{
    public class RestProfile: Profile
    {
        public RestProfile()
        {
            CreateMap<Agency, AgencyDTO>();
            CreateMap<Agency, CreateAgencyDTO>();
        }
    }
}
