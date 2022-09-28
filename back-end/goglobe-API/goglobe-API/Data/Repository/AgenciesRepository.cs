using goglobe_API.Data.Entities;
using goglobe_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goglobe_API.Data.Repository
{
    public class AgenciesRepository: IAgencyRepository
    {
        private readonly DatabaseContext _databaseContext;

        public AgenciesRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Agency>> GetAll() 
        {
            return await _databaseContext.Agencies.ToListAsync();
        }

        public async Task<Agency> Get(int id)
        {
            return await _databaseContext.Agencies.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<Agency> Create(Agency agency)
        {
            _databaseContext.Agencies.Add(agency);
            await _databaseContext.SaveChangesAsync();

            return agency;
        }

        public async Task<Agency> Put(Agency agency)
        {
            _databaseContext.Agencies.Update(agency);
            await _databaseContext.SaveChangesAsync();

            return agency;
        }

        public async Task Delete(Agency agency)
        {
            _databaseContext.Agencies.Remove(agency);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Agency> GetByName(string name)
        {
            return await _databaseContext.Agencies.FirstOrDefaultAsync(obj => obj.Name == name);
        }
    }
}