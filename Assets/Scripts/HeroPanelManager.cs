using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HeroPanelManager : MonoBehaviour
    {
        public Hero h;
        public Image playerImage;
        public Text nameText, infoText;
        private int iterator;
        // Use this for initialization
        void Start()
        {
            nameText = GetComponentsInChildren<Text>()[0];
            infoText = GetComponentsInChildren<Text>()[1];
        }

        // Update is called once per frame
        void Update()
        {
            if(iterator == 50)
            {
                iterator = 0;
                nameText.text = h.sName;
                infoText.text = "Level " + h.iLevel + " " + h.sRace + " " + h.sClassName;
            }
            iterator++;
        }
        public void PopupCharacterDetails()
        {

        }
    }
}