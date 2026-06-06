using System.Text.Json.Nodes;
using Prion.Node;

namespace Prion.Parser;

internal class PriJsonConverter
{
    public static JsonNode? PrionToJson(PriNode priNode)
    {
        return null;
    }
    public static PriNode JsonToPrion(JsonNode? jsonNode)
    {
        if(jsonNode is null) return PriNull.Null;
        switch (jsonNode.GetValueKind())
        {
            case System.Text.Json.JsonValueKind.Undefined:
            case System.Text.Json.JsonValueKind.Null:
                return PriNull.Null;
            case System.Text.Json.JsonValueKind.String:
                return new PriString(jsonNode.ToString());
            case System.Text.Json.JsonValueKind.Number:
                // Todo: handle infinity/nan bs
                if(!double.TryParse(jsonNode.ToString(), out double d)) return PriNull.Null;
                return new PriNumber(d);
            case System.Text.Json.JsonValueKind.True:
                return PriBool.True;
            case System.Text.Json.JsonValueKind.False:
                return PriBool.False;
            case System.Text.Json.JsonValueKind.Object:
                return JsonObjectToPrion(jsonNode.AsObject());
            case System.Text.Json.JsonValueKind.Array:
                return JsonArrayToPrion(jsonNode.AsArray());
            default:
                return PriNull.Null;
        }
    }
    private static PriNode JsonObjectToPrion(JsonObject jsonObject)
    {
        return PriNull.Null;
    }
    private static PriNode JsonArrayToPrion(JsonArray jsonArray)
    {
        return PriNull.Null;
    }
}