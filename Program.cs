using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterfaceCorrection
{
    class Program
    {
        static FightManager fightManager;

        static void Main()
        {
            List<Character> characters = new List<Character>
            {
                new Berseker("Berseker"),
                new Watcher("Gardien"),
                new Ghoul("Goule"),
                new Lich("Liche"),
                new Robot("Robot"),
                new Warrior("Guerrier"),
                new Zombie("Zombie")
            };

            fightManager = new FightManager(characters);
            fightManager.StartCombat();
        }

        public static int RoundToInt(float value)
        {
            return (int)Math.Round((double)value);
        }
    }
}
