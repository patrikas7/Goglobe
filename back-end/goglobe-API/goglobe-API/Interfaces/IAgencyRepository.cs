using goglobe_API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goglobe_API.Interfaces
{
    public interface IAgencyRepository
    {
        Task<IEnumerable<Agency>> GetAll();

        Task<Agency> Get(int id);

        Task<Agency> GetByName(string name);

        Task<Agency> Create(Agency agency);

        Task<Agency> Put(Agency agency);

        Task Delete(Agency agency);
    }
}
