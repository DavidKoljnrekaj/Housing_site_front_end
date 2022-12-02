using Model.DTOs;
using Model.Model;

namespace BlazorWASM.Services.ClientInterfaces;

public interface IListingService
{
    Task<ICollection<HouseListing>> getAsync(string? title, string? username);
    Task<HouseListing> CreateListing(HouseListingCreationDTO dto);
    Task<HouseListing> GetById(long id);
}