using AddressManager.Data;
using AddressManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressManager.Controllers
{
    [Route("api/v1/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ProjectContext _dbContext;

        public CountryController(ILogger<CountryController> logger
            , ProjectContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> Get()
        {
            var countries = await _dbContext.Countries
                .ToListAsync();

            return countries;
        }

        [HttpGet("{countryId}")]
        public async Task<ActionResult<Country>> Get(Guid countryId)
        {
            var country = await _dbContext.Countries
                .FirstOrDefaultAsync(p => p.Id == countryId);

            if (country is null)
                return NotFound();

            return country;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Country country)
        {
            await _dbContext.Countries.AddAsync(country);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("Get", new { countryId = country.Id }, country);
        }

        [HttpPut("{countryId}")]
        public async Task<ActionResult> Put(Guid countryId, Country country)
        {
            var currentCountry = await _dbContext.Countries
                .FirstOrDefaultAsync(c => c.Id.Equals(countryId));

            if (currentCountry is null)
            {
                currentCountry = country;
                await _dbContext.Countries.AddAsync(currentCountry);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction("Get", new { countryId }, currentCountry);
            }

            currentCountry.NumericCode = country.NumericCode;
            currentCountry.CountryName = country.CountryName;
            currentCountry.CountryDescription = country.CountryDescription;
            currentCountry.AlphaCode2 = country.AlphaCode2;
            currentCountry.AlphaCode3 = country.AlphaCode3;
            currentCountry.PhoneNumberCode = country.PhoneNumberCode;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{countryId}")]
        public async Task<ActionResult> Delete(Guid countryId)
        {
            var country = await _dbContext.Countries
                .FirstOrDefaultAsync(c => c.Id.Equals(countryId));

            if (country is null)
                return NotFound();

            _dbContext.Remove(country);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
