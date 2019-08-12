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
        public String sName, sRace, sClassName;
        public List<String> listProficiencies, listCantripsKnown, listLanguages, listSkillProficiencies, listSpellsKnown, listSpellsPrepared, listFeats, listBackgroundTraits, listInventory;


        public struct classVars {

        };
        //Barbarian variables


        //Bard variables


        //Cleric variables
        public String sDomain;
        public int iChannelDivinity;
        public int iMaxChannelDivinity;

        //Druid variables


        //Fighter variables
        public String sMartialArchetype;
        public bool bSecondWind;
        public int iActionSurge, iMaxActionSurge, iIndomitable, iMaxIndomitable, iSuperiorityDice, iMaxSuperiorityDice, iSpellSlots, iMaxSpellSlots;

        //Monk variables
        public int iMaxKi, iCurrentKi, iMonkDie, iUnarmoredSpeed;
        public String sPath;

        //Paladin variables


        //Ranger variables


        //Rogue variables


        //Sorcerer variables
        public String sorcerousOrigin;
        public int iCurrentSorceryPoints;
        public int iMaxSorceryPoints;

        //Warlock variables


        //Wizard variables


    }
}
