namespace BeerSender.Domain;

public class BeerPackage
{
    public BoxCapacity Capacity { get; set; }
    private ShippingLabel? Label { get; set; }
}