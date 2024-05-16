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

        private void LoadMonsters(string jsonFile)
        {
            JObject json = JObject.Parse(GetJsonString(jsonFile));
            foreach (var cardJson in json.SelectToken("cards").Children())
            {
                int id = cardJson.SelectToken("cardTypeId").Value<int>();
                Type type = GetCardType(id).ActualType;
                _Cards.Add((BaseCard)cardJson.ToObject(type));
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
