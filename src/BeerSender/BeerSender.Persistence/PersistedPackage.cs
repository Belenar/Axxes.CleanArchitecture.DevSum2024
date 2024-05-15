using BeerSender.Domain;

namespace BeerSender.Persistence;

public class PersistedPackage
{
    public int Id { get; set; }
    public int Capacity { get; set; }

    public static PersistedPackage FromPackage(BeerPackage package)
    {
        return new PersistedPackage
        {
            Capacity = package.Capacity.NumberOfBottles
        };
    }

    public BeerPackage ToPackage()
    {
        return new BeerPackage
        {
            Capacity = new BoxCapacity(Capacity)
        };
    }
}