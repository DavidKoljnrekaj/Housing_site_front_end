namespace Model.Model;

public class Address
{
    public string Street { get; set; }
    public int PostNumber{ get; set; }
    public string City{ get; set; }
    public int HouseNo{ get; set; }

    public Address(string street, int postNumber, string city, int houseNo)
    {
        Street = street;
        PostNumber = postNumber;
        City = city;
        HouseNo = houseNo;
    }
}