using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Assets.Scripts
{
    public class Hero : EncounterActor
    {
        public int iLevel, iXP, iProficiencyBonus, iNextLvlXP, iGold, iHPGainedPerLevel, iHitDie, iTotalNumHitDice, iCurrentNumHitDice;
        public int[] iArrayCurrentSpellSlots, iArrayMaxSpellSlots;
        public bool bInspiration;
        public string sName, sRace, sClassName;
        List<Spell> listSpellsKnown, listSpellsPrepared;
        List<string> listProficiencies, listKnownCantrips, listLanguages, listSkillProficiencies;
        Dictionary<string, int> dictSkills;
        Dictionary<string, bool> dictFeats;
        Dictionary<string, string> dictBackgroundTraits;

        List<Item> listInventory;
    }
}
