using UnityEngine;
using System.Collections.Generic;
namespace Assets.Scripts
{
    public class BoardManager : MonoBehaviour
    {
        public int columns;
        public int rows;
        private int iterator;
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
        public List<GameObject> previouslyInstantiatedTiles;
        private Transform boardHolder;

        // Use this for initialization
        void Start()
        {
            gm = GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            iterator++;
            if(iterator == 3000)
            {
                foreach(GameObject tileToBeDestroyed in previouslyInstantiatedTiles)
                {
                    Destroy(tileToBeDestroyed);
                }
                int row = 0;
                int col = 0;
                if (gm.activeCampaign.currentDungeon != null)
                {
                    this.currentDungeon = gm.activeCampaign.currentDungeon;
                }
                if (currentDungeon.dungeonMap != null)
                {
                    Debug.Log("current dungeon map != null, laying out board");
                    foreach (List<DungeonTile> dungeonTileList in currentDungeon.dungeonMap)
                    {
                        col = 0;
                        foreach (DungeonTile dTile in dungeonTileList)
                        {
                            GameObject instantiatedTile = null;
                            //if (dTile.dictHeroVisibility[gm.clientHero])
                            //{
                            if (dTile.bWall)
                            {
                                if (dTile.iTileType == -1)
                                {
                                    dTile.iTileType = (int)(Random.value * darkWallTiles.Length);
                                }
                                switch (dTile.iLightLevel)
                                {
                                    case 0:
                                        instantiatedTile = (GameObject)Instantiate(darkWallTiles[dTile.iTileType]);
                                        break;
                                    case 1:
                                        instantiatedTile = (GameObject)Instantiate(darkWallTiles[dTile.iTileType]);
                                        break;
                                    case 2:
                                        instantiatedTile = (GameObject)Instantiate(dimWallTiles[dTile.iTileType]);
                                        break;
                                    case 3:
                                        instantiatedTile = (GameObject)Instantiate(brightWallTiles[dTile.iTileType]);
                                        break;
                                }
                            }
                            else
                            {
                                if (dTile.iTileType == -1)
                                {
                                    dTile.iTileType = (int)(Random.value * darkFloorTiles.Length);
                                }
                                switch (dTile.iLightLevel)
                                {
                                    case 0:
                                        instantiatedTile = (GameObject)Instantiate(darkFloorTiles[dTile.iTileType]);
                                        break;
                                    case 1:
                                        instantiatedTile = (GameObject)Instantiate(darkFloorTiles[dTile.iTileType]);
                                        break;
                                    case 2:
                                        instantiatedTile = (GameObject)Instantiate(dimFloorTiles[dTile.iTileType]);
                                        break;
                                    case 3:
                                        instantiatedTile = (GameObject)Instantiate(brightFloorTiles[dTile.iTileType]);
                                        break;
                                }
                            }
                            //}
                            //else
                            //{
                            //    instantiatedTile = (GameObject)Instantiate(darknessTile);
                            //}
                            //Debug.Log("Attempting to create new tile at (" + row * 32 + ", " + col * 32 + "). Better coords are (" + row + ", " + col + ")");
                            if (instantiatedTile != null)
                            {
                                instantiatedTile.transform.Translate(new Vector3(row, col, 0));
                                previouslyInstantiatedTiles.Add(instantiatedTile);
                            }
                            else
                            {
                                Debug.Log("Instantiated tile can't be transformed if it doesn't exist... (" + row + ", " + col + ")");
                            }
                            col++;
                        }
                        row++;
                    }
                }
                iterator = 0;
            }
        }
    }
}