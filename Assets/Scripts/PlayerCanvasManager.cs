using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class PlayerCanvasManager : MonoBehaviour
    {
        public List<Hero> listParty;
        // Use this for initialization
        void Start()
        {
            this.listParty = GetComponentInParent<GameManager>().activeCampaign.listParty;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}