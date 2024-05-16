namespace MonsterHunter.LIB.model
{
    public class BaseMonster
    {
        public int id { get; set; }
        public string type { get; set; }
        public string species { get; set; }
        public string[] elements { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Ailment[] ailments { get; set; }
        public Location[] locations { get; set; }
        public Resistance[] resistances { get; set; }
        public Weakness[] weaknesses { get; set; }
        public Reward[] rewards { get; set; }
    }

    public class Ailment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Recovery recovery { get; set; }
        public Protection protection { get; set; }
    }

    public class Recovery
    {
        public string[] actions { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public int rarity { get; set; }
        public int value { get; set; }
        public int carryLimit { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Protection
    {
        public object[] skills { get; set; }
        public object[] items { get; set; }
    }

    public class Location
    {
        public int id { get; set; }
        public int zoneCount { get; set; }
        public string name { get; set; }
    }

    public class Resistance
    {
        public string element { get; set; }
        public object condition { get; set; }
    }

    public class Weakness
    {
        public string element { get; set; }
        public int stars { get; set; }
        public object condition { get; set; }
    }

    public class Reward
    {
        public int id { get; set; }
        public Item1 item { get; set; }
        public Condition[] conditions { get; set; }
    }

    public class Item1
    {
        public int id { get; set; }
        public int rarity { get; set; }
        public int carryLimit { get; set; }
        public int value { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Condition
    {
        public string type { get; set; }
        public string rank { get; set; }
        public int quantity { get; set; }
        public int chance { get; set; }
        public string subtype { get; set; }
    }

}
