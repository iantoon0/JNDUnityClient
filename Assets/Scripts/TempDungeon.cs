using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    [Serializable]
    public class TempDungeon
    {
        public List<DungeonTile> dungeonMap;
        //List<Encounter> encounters;
        public int size;
    }
}
