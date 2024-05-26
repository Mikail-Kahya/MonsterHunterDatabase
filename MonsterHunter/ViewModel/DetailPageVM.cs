using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MonsterHunter.Model;

namespace MonsterHunter.ViewModel
{
    internal class DetailPageVM : ObservableObject
    {
        private Monster _monster = new Monster()
        {
            Id = 2,
            Name = "Anjanath",
            Type = "Large",
            Species = "Brute Wyvern"
        };

        private List<string> _elements = new List<string>(); 

        public Monster Monster
        {
            get => _monster;
            set
            {
                _monster = value;
                OnPropertyChanged(nameof(Monster));
            }
        }

        public List<string> Elements
        {
            get => _elements;
            set
            {
                _elements = value;
                OnPropertyChanged(nameof(Elements));
            }
        }
    }
}
