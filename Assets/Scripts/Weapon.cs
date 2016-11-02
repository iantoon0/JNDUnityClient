using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Assets.Scripts
{
    [System.Serializable]
    class Weapon
    {
        private int iBonusDam, iBonusToHit;
        private bool bMagical;
        List<string> listProficiencyNames;
        List<int> iHitDice;
    }
}
