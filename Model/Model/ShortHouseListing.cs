namespace Model.Model;

public class ShortHouseListing
{
    public int Id;
    public ImageFile image;
    public Address address; 
    public int price;
    public int postalCode;

    public ShortHouseListing(int id, ImageFile image, Address address, int price, int postalCode)
    {
        Id = id;
        this.image = image;
        this.address = address;
        this.price = price;
        this.postalCode = postalCode;
    }
}