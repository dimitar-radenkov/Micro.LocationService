using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationService.Extensions;
using LocationService.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationService.Data
{
    public class LocationRepository : ILocationRepository
    {
        private readonly LocationServiceDbContext db;

        public LocationRepository(LocationServiceDbContext db)
        {
            this.db = db;
        }

        public async Task<Location> AddAsync(
            float latitude, 
            float longtitude, 
            float altitude, 
            Guid memberId)
        {
            var location = new Location
            {
                ID = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow.ToUnixTime(),
                Altitude = altitude,
                Latitude = latitude,
                Longitude = longtitude,
                MemberID = memberId,
            };

            await this.db.Locations.AddAsync(location);
            this.db.SaveChanges();

            return location;
        }

        public async Task<IEnumerable<Location>> AllForMemberAsync(Guid memberId)
        { 
            return await this.db.Locations
                .AsNoTracking()
                .Where(x => x.MemberID == memberId)
                .ToListAsync(); ;
        }

        public async Task<bool> DeleteAsync(Guid memberId, Guid recordId)
        {
            var result = await this.db.Locations
                .Where(x => x.MemberID == memberId && x.ID == recordId)
                .DeleteFromQueryAsync();

            this.db.SaveChanges();

            return result > 0;
        }

        public async Task<Location> GetAsync(Guid memberId, Guid recordId)
        {
            return await this.db.Locations
                .FirstOrDefaultAsync(x => x.MemberID == memberId && x.ID == recordId);
        }

        public async Task<Location> GetLatestForMemberAsync(Guid memberId)
        {
            return await this.db.Locations
                .AsNoTracking().LastOrDefaultAsync(x => x.MemberID == memberId);
        }

        public Task<Location> UpdateAsync(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
