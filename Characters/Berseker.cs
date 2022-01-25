using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterfaceCorrection
{
    class Berseker : LivingBeing
    {
        public Berseker(string name) : base(name, 100, 100, 80,20, 300, (ConsoleColor)1) { }

        public override void TakeDamages(int _damages)
        {
            base.TakeDamages(_damages);
            if (CurrentLife > 0)
            {
                Damages += _damages;
                MyLog("Les dégâts de " + Name + " augmente à " + Damages + ".");
            }
        }
    }
}
