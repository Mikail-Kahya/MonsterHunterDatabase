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
            Id = 136,
            Name = "Anjanath",
            Type = "Large wyvern",
        };

        public Monster Monster
        {
            get => _monster;
            set
            {
                _monster = value;
                OnPropertyChanged(nameof(Monster));
            }
        }
    }
}
