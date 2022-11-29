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
}