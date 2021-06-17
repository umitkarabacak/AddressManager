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
    [Route("api/v1/countries/{countryId}/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ILogger<ProjectContext> _logger;
        private readonly ProjectContext _dbContext;
        public CityController(ILogger<ProjectContext> logger
            , ProjectContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> Get()
        {
            var countries = await _dbContext.Cities
                .ToListAsync();

            return countries;
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<City>> Get(Guid cityId)
        {
            var city = await _dbContext.Cities
                .FirstOrDefaultAsync(p => p.Id == cityId);

            if (city is null)
                return NotFound();

            return city;
        }

        [HttpPost]
        public async Task<ActionResult> Post(City city)
        {
            await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("Get", new { cityId = city.Id, city.CountryId }, city);
        }

        [HttpPut("{cityId}")]
        public async Task<ActionResult> Put(Guid cityId, City city)
        {
            var currentCity = await _dbContext.Cities
                .FirstOrDefaultAsync(c => c.Id.Equals(cityId));

            if (currentCity is null)
            {
                currentCity = city;
                await _dbContext.Cities.AddAsync(currentCity);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction("Get", new { cityId, city.CountryId }, currentCity);
            }

            currentCity.CityName = city.CityName;
            currentCity.CityCode = city.CityCode;
            currentCity.CityDescription = city.CityDescription;
            currentCity.CountryId = city.CountryId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{cityId}")]
        public async Task<ActionResult> Delete(Guid cityId)
        {
            var city = await _dbContext.Cities
                .FirstOrDefaultAsync(c => c.Id.Equals(cityId));

            if (city is null)
                return NotFound();

            _dbContext.Remove(city);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
