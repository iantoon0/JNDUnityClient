using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Assets.Scripts
{
    
    public class EncounterActor
    {
        private int iStr, iCon, iDex, iIntel, iWis, iCha;
        private int iStrMod, iConMod, iDexMod, iIntelMod, iWisMod, iChaMod;
        private int iHP, iTempHP, iMaxHP, iInitiative, iInitiativeMod, iArmorClass, iMoveSpeed, iPassivePerception;
        public Boolean bSpellcaster, bHasTakenAction, bHasTakenBonusAction, bHasTakenReaction, bHasTakenMoveAction;
        public List<string> listActions, listBonusActions, listReactions, listMoveActions;
        public Dictionary<string, bool> dictStatusEffects;
    }
}
