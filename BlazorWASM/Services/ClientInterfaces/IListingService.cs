using Model.DTOs;
using Model.Model;

namespace BlazorWASM.Services.ClientInterfaces;

public interface IListingService
{
    Task<ICollection<ShortHouseListing>> getAsync(int? price, int? minArea, int? postcode);
    Task<HouseListing> CreateListing(HouseListingCreationDTO dto);
    Task<HouseListing> GetById(long id);
}