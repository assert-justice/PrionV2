using Prion.Node;
using Prion.Parser;
using Prion.Validator;

readonly struct Person: IPriSchema<Person>
{
    public int Id{get; init;}
    public string Name{get; init;}
    public string Rank{get; init;}
    public int BirthYear{get; init;}
    public int[] Parents{get; init;}
    public static bool TryFromPrion(PriNode priNode, out Person value)
    {
        value = default;
        if(priNode is not PriDict priDict) return false;
        if(!priDict.TryGet("id", out int id))
        {
            Console.WriteLine("no id");
            return false;
        }
        if(!priDict.TryGet("name", out string name))
        {
            Console.WriteLine("no name");
            return false;
        }
        if(!priDict.TryGet("rank", out string rank))
        {
            Console.WriteLine("no rank");
            return false;
        }
        if(!priDict.TryGet("birth_year", out int birthYear))
        {
            Console.WriteLine("no birth year");
            return false;
        }
        if(!priDict.TryGetList("parents", out int[] parentIds)) parentIds = [];
        value = new()
        {
            Id = id,
            Name = name,
            Rank = rank,
            BirthYear = birthYear,
            Parents = parentIds,
        };
        // if(!priDict.Data.TryGetValue("id", out var idNode)) return false;
        // if(idNode is not PriNumber idNumber) return false;
        // int id = (int)idNumber.Value;

        return true;
    }
    public PriNode ToPrion()
    {
        PriDict dict = new();
        dict.TrySet("id", Id);
        dict.TrySet("name", Name);
        dict.TrySet("rank", Rank);
        dict.TrySet("birth_year", BirthYear);
        if(Parents.Length > 0) dict.TrySetList("parents", Parents);
        return dict;
    }
    public override string ToString()
    {
        return $"id: {Id}\nname: {Name}\nrank: {Rank}\nbirth year: {BirthYear}";
    }
}
class SchemaDemo
{
    private static void Main()
    {
        string src = File.ReadAllText("Examples/Data/person.pri");
        PriParser parser = new();
        if(!parser.TryParse(src, out var priNode))
        {
            Console.WriteLine("oops");
            return;
        }
        if(!Person.TryFromPrion(priNode, out var person))
        {
            Console.WriteLine("darn");
            return;
        }
        Console.WriteLine(person);
        Console.WriteLine(parser.PrettyPrint(person.ToPrion()));
        // Console.WriteLine($"id: {person.Id}, name: {person.Name}, rank: {person.Rank}, birth year: {person.BirthYear}");
        src = File.ReadAllText("Examples/Data/people.pri");
        if(!parser.TryParse(src, out priNode))
        {
            Console.WriteLine("fuck");
            return;
        }
        // Console.WriteLine(priNode);
        if(priNode is not PriList priList)
        {
            Console.WriteLine("balls");
            return;
        }
        foreach (var item in priList.Values)
        {
            if(!Person.TryFromPrion(item, out person))
            {
                Console.WriteLine("mother fuck");
                return;
            }
            Console.WriteLine(person);
            Console.WriteLine(parser.PrettyPrint(person.ToPrion()));
        }
    }
}