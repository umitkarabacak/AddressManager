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
    [Route("api/v1/countries/{countryId}/cities/{cityId}/districts")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly ILogger<DistrictController> _logger;
        private readonly ProjectContext _dbContext;

        public DistrictController(ILogger<DistrictController> logger
            , ProjectContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<District>> Get()
        {
            var districts = await _dbContext.Districts
                .ToListAsync();

            return districts;
        }

        [HttpGet("{districtId}")]
        public async Task<ActionResult<District>> Get(Guid districtId)
        {
            var district = await _dbContext.Districts
                .FirstOrDefaultAsync(p => p.Id == districtId);

            if (district is null)
                return NotFound();

            return district;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Guid countryId, District district)
        {
            await _dbContext.Districts.AddAsync(district);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("Get", new { countryId, cityId = district.CityId, districtId = district.Id }, district);
        }

        [HttpPut("{districtId}")]
        public async Task<ActionResult> Put(Guid countryId, Guid districtId, District district)
        {
            var currentDistrict = await _dbContext.Districts
                .FirstOrDefaultAsync(c => c.Id.Equals(districtId));

            if (currentDistrict is null)
            {
                currentDistrict = district;
                await _dbContext.Districts.AddAsync(currentDistrict);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction("Get", new { countryId, cityId = district.CityId, districtId = district.Id }, district);
            }

            currentDistrict.DistrictName = district.DistrictName;
            currentDistrict.DistrictCode = district.DistrictCode;
            currentDistrict.DistrictDescription = district.DistrictDescription;
            currentDistrict.CityId = district.CityId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{districtId}")]
        public async Task<ActionResult> Delete(Guid districtId)
        {
            var district = await _dbContext.Districts
                .FirstOrDefaultAsync(c => c.Id.Equals(districtId));

            if (district is null)
                return NotFound();

            _dbContext.Remove(district);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
