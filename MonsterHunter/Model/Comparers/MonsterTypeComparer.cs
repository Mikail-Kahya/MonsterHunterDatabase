using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterHunter.Model;
namespace MonsterHunter.Model.Comparers
{
    class MonsterTypeComparer : IEqualityComparer<Monster>
    {
        public bool Equals(Monster? x, Monster? y)
        {
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(x, null) ||
                object.ReferenceEquals(y, null)) 
                return false;

            return x.Type == y.Type;
        }

        public int GetHashCode(Monster obj)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(obj, null)) return 0;

            return obj.Id;
        }
    }
}
