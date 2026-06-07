using System.Text.Json.Nodes;
using Prion.Node;
using Prion.Parser;

// string src = "\"Hello, World!\"";
// string src = "[null,true,[false,true]]";
// string src = "{key: \"value\", other_key: 100.f64}";
string src = File.ReadAllText("Examples/Data/people.json");
JsonNode? jsonNode = JsonNode.Parse(src);
PriParser parser = new();
PriNode pri = parser.JsonToPrion(jsonNode);
Console.WriteLine(parser.PrettyPrint(pri));
// if(parser.TryParse(src, out var priNode))
// {
//     Console.WriteLine(priNode.ToString());
// }
