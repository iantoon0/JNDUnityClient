using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Campaign
    {
        public List<Hero> listParty;
        List<Spell> listActiveSpells;
        Dictionary<String, List<TextMessage>> dictChatLog;
        public Time currentTime;
        bool bInEncounter;
        public List<Dungeon> listDungeons;
        public Dungeon currentDungeon;

        public string toString()
        {
            string writeString = "";
            if(listParty != null)
            {
                foreach (Hero h in listParty)
                {
                    writeString.Insert(writeString.Length, h.sName);
                }
            }
            return writeString;
        }
    }
}
