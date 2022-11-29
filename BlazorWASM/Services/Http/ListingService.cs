using System.Text;
using System.Text.Json;
using BlazorWASM.Services.ClientInterfaces;
using Model.DTOs;
using Model.Model;

namespace BlazorWASM.Services.Http;

public class ListingService : IListingService
{
    private readonly HttpClient client;

    public ListingService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<HouseListing> CreateListing(HouseListingCreationDTO dto)
    {
        string listingAsJson = JsonSerializer.Serialize(dto);
        StringContent content = new(listingAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://localhost:/listings", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
        HouseListing listing = JsonSerializer.Deserialize<HouseListing>(responseContent, new JsonSerializerOptions{
            PropertyNameCaseInsensitive = true
        })!;
        return listing;
    }
}