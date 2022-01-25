using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterfaceCorrection
{
    class LivingBeing : Character
    {
        public LivingBeing(string name, int attack, int defense, int initiative, int damages, int maxLife, ConsoleColor _color) : base(name, attack, defense, initiative, damages, maxLife, color:_color)
        {

        }
    }
}
