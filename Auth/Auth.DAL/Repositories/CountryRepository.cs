using Auth.DAL.Data;
using Auth.DAL.Interfaces;
using Auth.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.DAL.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countrys.ToListAsync();
        }

        public async Task<Country> GetCountryAsync(Guid countryId) => _context.Countrys!.FirstOrDefault(c => c.Id == countryId);

        public async Task<bool> IsCountryExistAsync(Guid countryId)
        {
            Country country = _context.Countrys!.Where(c => c.Id == countryId).FirstOrDefault();

            return country != null ? true : false;
        }
    }
}
