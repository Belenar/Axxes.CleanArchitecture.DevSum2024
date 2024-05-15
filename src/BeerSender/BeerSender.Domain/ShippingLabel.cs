namespace BeerSender.Domain;

public record ShippingLabel(string Carrier, string Code)
{
    public bool IsValid {
        get
        {
            switch (Carrier)
            {
                case "UPS":
                    return Code.StartsWith("ABC");
                case "DHL":
                    return Code.EndsWith("DEF");
                case "PostNord":
                    return Code.StartsWith("SE");
                default:
                    return true;
            }
        }
    }
}