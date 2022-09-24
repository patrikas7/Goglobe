using goglobe_API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goglobe_API.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAll();
        Task<Booking> Get(int id);

        Task<Booking> Create(Booking booking);

        Task<Booking> Put(Booking booking);

        Task Delete(Booking booking);
    }
}
