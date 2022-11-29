namespace Model.Model;
public class HouseListing
{
    private long id;
    private Address address;
    private int ConstructionYear;
    private int LastRebuilt;
    private bool HasInspection;
    private double GroundArea;
    private double FloorArea;
    private List<ImageFile> images;
    //private date listing date;
    private long price;
}