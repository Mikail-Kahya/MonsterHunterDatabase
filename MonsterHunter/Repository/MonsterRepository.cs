using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        private List<string> _elements = new List<string>();
        public List<Monster> Monsters => _monsters;
        public List<string> Types => _types;
        public List<string> Elements => _elements;

        public List<Monster> GetAllMonsters(string type)
        {
            List<Monster> monsterList = new List<Monster>();
            foreach (var monster in _monsters)
            {
                if (monster.Species == type)
                    monsterList.Add(monster);
            }

            return monsterList;
        }

        public async Task SetupRepo(string path, string backUpJsonFile)
        {
            _monsters = await LoadJson(path, backUpJsonFile);
            GetUniqueTypes();
            GetUniqueElements();
        }

        private void GetUniqueTypes()
        {
            foreach (Monster uniqueMonster in _monsters.DistinctBy(monster => monster.Species))
                _types.Add(uniqueMonster.Species);
        }

        private void GetUniqueElements()
        {
            foreach (Monster monster in Monsters)
            {
                foreach (string element in monster.Elements)
                    if(!_elements.Contains(element))
                        _elements.Add(element);
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

        private async Task<List<Monster>> LoadJson(string path, string backUpJsonFile)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(path);

                    if (!response.IsSuccessStatusCode)
                        throw new HttpRequestException(response.ReasonPhrase);

                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Monster>>(json);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return JsonConvert.DeserializeObject<List<Monster>>(GetJsonString(backUpJsonFile));
                }
            }

        }
    }
}
