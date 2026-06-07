
using Prion.Parser;

// string src = "\"Hello, World!\"";
// string src = "[null,true,[false,true]]";
string src = File.ReadAllText("Examples/Data/people.pri");
// string src = "{key: \"value\", other_key: 100.f64}";
PriParser parser = new();
if(parser.TryParse(src, out var priNode))
{
    Console.WriteLine(priNode.ToString());
}
