using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterHunter.LIB.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MonsterHunter.model
{
    public class MonsterRespository
    {
        private List<BaseMonster> _Monsters = new List<BaseMonster>();
        public List<BaseMonster> Monsters => _Monsters;

        private void LoadMonsters(string jsonFile)
        {
            string jsonstring = GetJsonString(jsonFile);
            JObject json = JObject.Parse(jsonstring);
            foreach (var cardJson in json.SelectToken("monsters").Children())
            {
                _Monsters.Add(cardJson.ToObject<BaseMonster>());
            }
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

        public MonsterRespository(string jsonFile)
        {
            LoadMonsters(jsonFile);
        }
    }
}
