
using System.Text.Json.Nodes;
using Prion.Parser;

string src = File.ReadAllText("Examples/Data/people.json");
var jsonNode = JsonNode.Parse(src);
PriParser parser = new();
var pri = parser.JsonToPrion(jsonNode);
Console.WriteLine(parser.PrettyPrint(pri));
