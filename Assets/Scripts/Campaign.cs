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
        //Dictionary<String, List<TextMessage>> dictChatLog;
        public Time currentTime;
        bool bInEncounter;
        public List<Dungeon> listDungeons;
        public List<TempDungeon> listTempDungeons;
        public Dungeon currentDungeon;
        public TempDungeon currentTempDungeon;

        public void toNormalDungeons()
        {
            this.currentDungeon = new Dungeon(currentTempDungeon);
            foreach(List<DungeonTile> dTileList in this.currentDungeon.dungeonMap)
            {
                foreach(DungeonTile dTile in dTileList)
                {
                    dTile.iTileType = -1;
                }
            }
        }

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
