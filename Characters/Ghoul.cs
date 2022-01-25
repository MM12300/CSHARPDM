using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterfaceCorrection
{
    class Ghoul : Undead, IScavenger
    {
        public Ghoul(string name) : base(name, 80, 80, 120, 30, 250, (ConsoleColor)2)
        {

        }

        public void EatBody()
        {
            CurrentLife += random.Next(50, 101);
            CurrentLife = Math.Min(CurrentLife, MaxLife);
            MyLog(Name + " mange un corps. Sa vie est maintenant à " + CurrentLife + ".");
        }
    }
}
