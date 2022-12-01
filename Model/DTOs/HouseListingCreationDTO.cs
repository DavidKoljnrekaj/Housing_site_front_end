using Model.Model;

namespace Model.DTOs;

public class HouseListingCreationDTO
{
    private Address adress;
    private int ConstructionYear;
    private int LastRebuilt;
    private bool HasInspection;
    private double GroundArea;
    private double FloorArea;
    private List<ImageFile> images;
    private long price;

    public HouseListingCreationDTO(Address adress, int constructionYear, int lastRebuilt, bool hasInspection, double groundArea, double floorArea, List<ImageFile> images, long price)
    {
        this.adress = adress;
        ConstructionYear = constructionYear;
        LastRebuilt = lastRebuilt;
        HasInspection = hasInspection;
        GroundArea = groundArea;
        FloorArea = floorArea;
        this.images = images;
        this.price = price;
    }
}