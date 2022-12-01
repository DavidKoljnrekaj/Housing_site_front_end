namespace Model.Model;
public class HouseListing
{
    public long id { get; set; }
    public Address address;
    public int ConstructionYear;
    public int LastRebuilt;
    public bool HasInspection;
    public double GroundArea;
    public double FloorArea;
    public List<ImageFile> images;
    //private date listing date;
    public long price;
    public HouseListing(Address address, int constructionYear, int lastRebuilt, bool hasInspection, double groundArea, double floorArea, List<ImageFile> images, long price, long id)
    {
        this.address = address;
        ConstructionYear = constructionYear;
        LastRebuilt = lastRebuilt;
        HasInspection = hasInspection;
        GroundArea = groundArea;
        FloorArea = floorArea;
        this.images = images;
        this.price = price;
        this.id = id;
    }
    
}