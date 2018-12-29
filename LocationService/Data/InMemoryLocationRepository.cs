using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationService.Extensions;
using LocationService.Models;

namespace LocationService.Data
{
    public class InMemoryLocationRepository : ILocationRepository
    {
        private IList<Location> locationsList;

        public InMemoryLocationRepository()
        {
            this.locationsList = new List<Location>();
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

            await Task.Run(() => this.locationsList.Add(location));

            return location;
        }

        public async Task<IEnumerable<Location>> AllForMemberAsync(Guid memberId)
        { 
            return await Task.Run(() => this.locationsList.Where(x => x.MemberID == memberId));
        }

        public async Task<bool> DeleteAsync(Guid memberId, Guid recordId)
        {
            var location = await Task.Run(() => 
                this.locationsList.FirstOrDefault(l => l.MemberID == memberId && l.ID == recordId));

            if (location != null)
            {
                this.locationsList.Remove(location);
                return true;
            }

            return false;
        }

        public async Task<Location> GetAsync(Guid memberId, Guid recordId)
        {
            return await Task.Run(() => 
                this.locationsList.FirstOrDefault(l => l.MemberID == memberId && l.ID == recordId));
        }

        public async Task<Location> GetLatestForMemberAsync(Guid memberId)
        {
            return await Task.Run(() => 
                this.locationsList.LastOrDefault(l => l.MemberID == memberId));
        }

        public Location Update(Location location)
        {
            var existingLocation = this.locationsList
                .FirstOrDefault(x => x.ID == location.ID && x.MemberID == location.MemberID);

            if (existingLocation == null)
            {
                return null;
            }

            var index = this.locationsList.IndexOf(existingLocation);
            this.locationsList[index] = location;

            return location;
        }

        public Task<Location> UpdateAsync(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
