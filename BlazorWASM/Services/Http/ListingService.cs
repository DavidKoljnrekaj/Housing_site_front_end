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
        /*
        HttpResponseMessage response = await client.GetAsync("https://localhost:/listings/"+id);
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
        HouseListing listing = JsonSerializer.Deserialize<HouseListing>(responseContent, new JsonSerializerOptions{
            PropertyNameCaseInsensitive = true
        })!;
        return listing;
*/
        var list = new List<ImageFile>();
        list.Add(new ImageFile { base64data = ImageFile.getRandom64(), contentType = "image/png", fileName = " file.Name" });
        list.Add(new ImageFile { base64data = ImageFile.getRandom645(), contentType = "image/png", fileName = " file.Namee" });
        list.Add(new ImageFile { base64data = ImageFile.getRandom64(), contentType = "image/png", fileName = " file.Nameee" });
        return new HouseListing(new Address("Sonderbrogade", 8700, "Horsens", 31), 2014, 2015, true, 56, 204, list, 100000, 2);

    }

}