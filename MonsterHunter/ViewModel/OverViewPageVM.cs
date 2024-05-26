using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MonsterHunter.Model;
using MonsterHunter.Repository;

namespace MonsterHunter.ViewModel
{
    public class OverViewPageVM : ObservableObject
    {
        private MonsterRepository _repo = new MonsterRepository("Resources/Data/monsters.json");
        private string _selectedType = "";
        private Monster _selectedMonster;
        private List<string> _monsterTypes;
        private List<string> _elements;
        private List<Monster> _monsters;

        public List<string> MonsterTypes
        {
            get => _monsterTypes;
            private set
            {
                _monsterTypes = value;
                OnPropertyChanged(nameof(MonsterTypes));
            }
        }

        public List<string> Elements
        {
            get => _elements;
            private set
            {
                _elements = value;
                OnPropertyChanged(nameof(Elements));
            }
        }

        public List<Monster> Monsters
        {
            get => _monsters;
            private set
            {
                _monsters = value;
                OnPropertyChanged(nameof(Monsters));
            }
        }

        public string SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                Monsters = _repo.GetAllMonsters(_selectedType);
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        public Monster SelectedMonster
        {
            get => _selectedMonster;
            set
            {
                _selectedMonster = value;
                OnPropertyChanged(nameof(SelectedMonster));
            }
        }

        public OverViewPageVM()
        {
            MonsterTypes = _repo.Types;
            Monsters = _repo.Monsters;
            Elements = _repo.Elements;
        }
    }
}
