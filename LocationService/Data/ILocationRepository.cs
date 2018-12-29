using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationService.Models;

namespace LocationService.Data
{
    public interface ILocationRepository
    {
        Task<Location> AddAsync(
            float latitude,
            float longtitude,
            float altitude,
            Guid memberId);

        Task<Location> UpdateAsync(Location location);

        Task<Location> GetAsync(Guid memberId, Guid recordId);

        Task<bool> DeleteAsync(Guid memberId, Guid recordId);

        Task<Location> GetLatestForMemberAsync(Guid memberId);

        Task<IEnumerable<Location>> AllForMemberAsync(Guid memberId);
    }
}
