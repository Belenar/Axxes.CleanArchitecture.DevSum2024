namespace BeerSender.Domain;

public record BoxCapacity(int NumberOfBottles)
{
    // Factory methods
    public static BoxCapacity Create(int desiredNumberOfBottles)
    {
        return desiredNumberOfBottles switch
        {
            <= 6 => new BoxCapacity(6),
            <= 12 => new BoxCapacity(12),
            _ => new BoxCapacity(24)
        };
    }
}