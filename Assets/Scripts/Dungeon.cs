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
        List<Encounter> encounters;
        int size;
    }
}