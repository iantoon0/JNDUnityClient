using UnityEngine;
using System.Collections.Generic;
namespace Assets.Scripts
{
    public class BoardManager : MonoBehaviour
    {
        public int columns;
        public int rows;
        public GameManager gm;
        public Dungeon currentDungeon;

        public GameObject darknessTile;
        public GameObject[] brightFloorTiles;
        public GameObject[] dimFloorTiles;
        public GameObject[] darkFloorTiles;
        public GameObject[] enemyTiles;
        public GameObject[] brightWallTiles;
        public GameObject[] dimWallTiles;
        public GameObject[] darkWallTiles;
        public GameObject[] heroTiles;

        private Transform boardHolder;

        // Use this for initialization
        void Start()
        {
            gm = GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            int row = 0;
            int col = 0;
            if (currentDungeon != null)
            {
                this.currentDungeon = gm.activeCampaign.currentDungeon;
                Debug.Log("CurrentDungeon != null!!!");
                foreach (List<DungeonTile> dungeonTileList in currentDungeon.dungeonMap)
                {
                    foreach (DungeonTile dTile in dungeonTileList)
                    {
                        GameObject instantiatedTile = null;
                        //if (dTile.dictHeroVisibility[gm.clientHero])
                        //{
                        if (dTile.bWall)
                        {
                            switch (dTile.lightLevel)
                            {
                                case 0:
                                    instantiatedTile = (GameObject)Instantiate(darkWallTiles[(int)(Random.value * darkWallTiles.Length)]);
                                    break;
                                case 1:
                                    instantiatedTile = (GameObject)Instantiate(darkWallTiles[(int)(Random.value * darkWallTiles.Length)]);
                                    break;
                                case 2:
                                    instantiatedTile = (GameObject)Instantiate(dimWallTiles[(int)(Random.value * dimWallTiles.Length)]);
                                    break;
                                case 3:
                                    instantiatedTile = (GameObject)Instantiate(brightWallTiles[(int)(Random.value * brightWallTiles.Length)]);
                                    break;
                            }
                        }
                        else
                        {
                            switch (dTile.lightLevel)
                            {
                                case 0:
                                    instantiatedTile = (GameObject)Instantiate(darkFloorTiles[(int)(Random.value * darkFloorTiles.Length)]);
                                    break;
                                case 1:
                                    instantiatedTile = (GameObject)Instantiate(darkFloorTiles[(int)(Random.value * darkFloorTiles.Length)]);
                                    break;
                                case 2:
                                    instantiatedTile = (GameObject)Instantiate(dimFloorTiles[(int)(Random.value * dimFloorTiles.Length)]);
                                    break;
                                case 3:
                                    instantiatedTile = (GameObject)Instantiate(brightFloorTiles[(int)(Random.value * brightFloorTiles.Length)]);
                                    break;
                            }
                        }
                        //}
                        //else
                        //{
                        //    instantiatedTile = (GameObject)Instantiate(darknessTile);
                        //}
                        col++;
                        instantiatedTile.transform.Translate(new Vector3(32 * row, 32 * col, 0));
                    }
                    row++;
                }
            }
        }
    }
}