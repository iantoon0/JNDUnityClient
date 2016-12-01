using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    [System.Serializable]
    public class DungeonTile
    {
        public Point loc;
        //public List<Point> surroundingPoints;
        //public List<LightSource> lightSources;
        //public List<Object> contents, n_Wallcontents, e_Wallcontents, s_Wallcontents, w_WallContents;
        //public Dictionary<Hero, Boolean> dictHeroVisibility;
        //public EncounterActor encounterActor;
        //public Hero h;
        //public Monster m;
        public int iLightLevel, iTileType; //0-3, Magic dark/Total dark/Dim/Bright
        public bool bVisible, bWasSeen, bWall, bIsDifficultTerrain;
    }
}
