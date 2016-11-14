using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Hero : EncounterActor
    {
        public int iLevel, iXP, iProficiencyBonus, iNextLvlXP, iGold, iHPGainedPerLevel, iSize;
        public int[] iArrayCurrentSpellSlots, iArrayMaxSpellSlots;
        public List<int> iArrayMaxHitDice, iArrayCurrentHitDice;
        public bool bInspiration;
        public string sName, sRace, sClassName;
        List<Spell> listSpellsKnown, listSpellsPrepared;
        List<string> listProficiencies, listKnownCantrips, listLanguages, listSkillProficiencies;
        Dictionary<string, int> dictSkills, dictClassLevels;
        Dictionary<string, bool> dictFeats;
        Dictionary<string, string> dictBackgroundTraits;

        List<Item> listInventory;

        //Barbarian variables


        //Bard variables


        //Cleric variables
        String sDomain;
        int iChannelDivinity;
        int iMaxChannelDivinity;

        //Druid variables


        //Fighter variables
        public String sMartialArchetype;
        public bool bSecondWind;
        public int iActionSurge, iMaxActionSurge, iIndomitable, iMaxIndomitable, iSuperiorityDice, iMaxSuperiorityDice, iSpellSlots, iMaxSpellSlots;

        //Monk variables
        int iMaxKi, iCurrentKi, iMonkDie, iUnarmoredSpeed;
        String sPath;

        //Paladin variables


        //Ranger variables


        //Rogue variables


        //Sorcerer variables
        String sorcerousOrigin;
        int iCurrentSorceryPoints;
        int iMaxSorceryPoints;

        //Warlock variables


        //Wizard variables


    }
}
