using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterfaceCorrection
{
    class Warrior : LivingBeing
    {
        public Warrior(string name) : base(name, 100, 100, 50, 100, 200, (ConsoleColor)5) { }
    }
}
