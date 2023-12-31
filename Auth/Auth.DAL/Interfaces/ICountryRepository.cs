﻿using Auth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DAL.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<bool> IsCountryExistAsync(Guid countryId);
        Task<Country> GetCountryAsync(Guid countryId);
    }
}
