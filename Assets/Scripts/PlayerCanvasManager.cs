using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class PlayerCanvasManager : MonoBehaviour
    {
        public List<Hero> listParty;
        public List<GameObject> createdPanels;
        public GameObject playerPanel, createdPanel;
        public int iterator = 0;
        // Use this for initialization
        void Start()
        {
            this.listParty = GetComponentInParent<GameManager>().activeCampaign.listParty;
            foreach (Hero h in listParty)
            {
                createdPanel = (GameObject)Instantiate(playerPanel, transform);
                createdPanels.Add(createdPanel);
                createdPanel.GetComponent<HeroPanelManager>().h = h;
                createdPanel.transform.position = new Vector3(0, 0, 0);
                createdPanel.transform.localPosition = new Vector3(0, 0, 0);
            }
        }

        // Update is called once per frame
        void Update()
        {
            iterator++;
            if (iterator == 30)
            {
                foreach(Hero h in GetComponentInParent<GameManager>().activeCampaign.listParty)
                {
                    if (listParty.Contains(h))
                    {

                    }
                    else
                    {
                        listParty.Add(h);
                        createdPanel = (GameObject)Instantiate(playerPanel, transform);
                        createdPanels.Add(createdPanel);
                        createdPanel.GetComponent<HeroPanelManager>().h = h;
                        createdPanel.transform.position = new Vector3(this.transform.position.x, (-100 * createdPanels.IndexOf(createdPanel)) + Screen.height, 0);
                    }
                }
                iterator = 0;
            }
        }
    }
}