using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    //캐릭터의 상태를 저장하는 class
    public class Character
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int HP { get; set; }
        public int Gold { get; set; }
        public int plusAttack = 0;
        public int plusDefense = 0;

        public Character(string name, string job, int level, int attack, int defense, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Attack = attack;
            Defense = defense;
            HP = hp;
            Gold = gold;
        }
        public void CharacterInfo()
        {
            Console.WriteLine("Lv . " + Level);
            Console.WriteLine(Name + " " + Job);
            Console.WriteLine("공격력 : " + Attack + " (" + plusAttack + ")");
            Console.WriteLine("방어력 : " + Defense+ " (" + plusDefense + ")");
            Console.WriteLine("체 력 : " + HP);
            Console.WriteLine("Gold : " + Gold);
        }
    }
}
