using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterHunter.Model;
using MonsterHunter.Model.Comparers;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MonsterHunter.Repository
{
    public class MonsterRepository
    {
        private List<Monster> _monsters = new List<Monster>();
        private List<string> _types = new List<string>();
        public List<Monster> Monsters => _monsters;
        public List<string> Types => _types;

        public List<Monster> GetAllPokemon(string type)
        {
            List<Monster> monsterList = new List<Monster>();
            foreach (var monster in _monsters)
            {
                if (monster.Type == type)
                    monsterList.Add(monster);
            }

            return monsterList;
        }

        public MonsterRepository(string jsonFile)
        {
            _monsters = JsonConvert.DeserializeObject<List<Monster>>(GetJsonString(jsonFile));
            GetUniqueTypes();
        }

        private void GetUniqueTypes()
        {
            foreach (Monster uniqueMonster in _monsters.DistinctBy(monster => monster.Type))
                _types.Add(uniqueMonster.Type);
        }

        private string? GetJsonString(string file)
        {
            // executing assembly
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            // generated embedded resource name: namespace.subfolder.filename
            string resourceName = "MonsterHunter." + file.Replace('/', '.');

            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
