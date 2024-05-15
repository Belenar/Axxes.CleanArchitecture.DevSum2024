namespace BeerSender.Domain;

public class ShippingLabelWithException
{
    public string Carrier { get; }
    public string Code { get; }

    public ShippingLabelWithException(string carrier, string code)
    {
        Carrier = carrier;
        Code = code;
        if (!IsValid(carrier, code))
            throw new Exception("Invalid shipping label");
    }

    public bool IsValid(string carrier, string code)
    {
        switch (carrier)
        {
            case "UPS":
                return code.StartsWith("ABC");
            case "DHL":
                return code.EndsWith("DEF");
            case "PostNord":
                return code.StartsWith("SE");
            default:
                return true;
        }
    }
}