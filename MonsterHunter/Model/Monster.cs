using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MonsterHunter.Model
{
    public class Monster
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Species { get; set; }
        public string[] Elements { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Location[] Locations { get; set; }
        public Resistance[] Resistances { get; set; }
        public Weakness[] Weaknesses { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public int ZoneCount { get; set; }
        public string Name { get; set; }
    }

    public class Resistance
    {
        public string Element { get; set; }
        public object Condition { get; set; }
    }

    public class Weakness
    {
        public string Element { get; set; }
        public int Stars { get; set; }
        public object Condition { get; set; }
    }
}
