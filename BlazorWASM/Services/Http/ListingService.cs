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

        HouseListing listing = JsonSerializer.Deserialize<HouseListing>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return listing;
    }

    public async Task<HouseListing> GetById(long id)
    {
        HttpResponseMessage response = await client.GetAsync("https://localhost:/houselisting/"+id);
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
    
    public async Task<HouseListing> addListing(HouseListingCreationDTO dto)
    {
        string listingAsJson = JsonSerializer.Serialize(dto);
        StringContent content = new(listingAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://localhost:7164/houselisting", content);
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

    public async Task<ICollection<ShortHouseListing>> getAsync(int? price, int? minArea, int? postcode)
    {
        string query = "";
        if (!(price == null)) 
        {
            query += $"?maxPrice={price}";
        }
        else if (!(minArea == null)) 
        {
            query += $"?minArea={minArea}";
        }
        else if (!(postcode == null)) 
        {
            query += $"?postNumber={postcode}";
        }
        
        HttpResponseMessage response = await client.GetAsync("/houselistings" + query);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<ShortHouseListing> listings = JsonSerializer.Deserialize<ICollection<ShortHouseListing>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return listings;
    }
}