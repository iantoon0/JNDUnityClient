using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Dungeon
    {
        public List<List<DungeonTile>> dungeonMap;
        //List<Encounter> encounters;
        public int size;
        public Dungeon(TempDungeon currentTempDungeon){
            List<List<DungeonTile>> tempDungeonMap = new List<List<DungeonTile>>();
            int i = 0;
            for (int r = 0; r < currentTempDungeon.size; r++)
            {
                tempDungeonMap.Add(new List<DungeonTile>());
                for (int c = 0; c < currentTempDungeon.size; c++)
                {
                    i = (r * currentTempDungeon.size) + c;
                    tempDungeonMap[r].Add(currentTempDungeon.dungeonMap[i]);
                }
            }
            this.dungeonMap = tempDungeonMap;
        }
    }
}