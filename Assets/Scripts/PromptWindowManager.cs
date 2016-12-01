using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
namespace Assets.Scripts
{
    public class PromptWindowManager : MonoBehaviour
    {
        public Text promptText, buttonText, answerText;
        public Button button;
        public GameObject createdPanel, textPanel, dropdown1Panel, dropdown2Panel, dropdown3Panel;
        JavaNetworkDungeonsProtocol jndp;
        Dropdown[] dropdowns = new Dropdown[0];
        // Use this for initialization
        void Start()
        {
            createdPanel = (GameObject) Instantiate(textPanel, transform);
            createdPanel.transform.position = new Vector3(0, 0, 0);
            createdPanel.transform.localPosition = new Vector3(0, 0, 0);
            Text[] textComponents = GetComponentsInChildren<Text>();
            promptText = textComponents[0];
            answerText = textComponents[1];
            button = GetComponentInChildren<Button>();
            button.onClick.AddListener(SubmitChoices);
            promptText.text = "Enter the address to connect to";
            this.jndp = GetComponentInParent<JavaNetworkDungeonsProtocol>();
        }
        // Update is called once per frame
        void Update()
        {

        }
        public void PromptPopup(Prompt p)
        {
            Debug.Log("Creating a prompt popup...");
            Text[] textComponents = new Text[0];
            switch (p.iNumSelectable) {
                case 1:
                    createdPanel = (GameObject)Instantiate(dropdown1Panel, transform);
                    createdPanel.transform.position = new Vector3(0, 0, 0);
                    createdPanel.transform.localPosition = new Vector3(0, 0, 0);
                    textComponents = GetComponentsInChildren<Text>();
                    promptText = textComponents[0];
                    dropdowns = GetComponentsInChildren<Dropdown>();
                    dropdowns[0].ClearOptions();
                    dropdowns[0].AddOptions(p.sPromptOptions);
                    button = GetComponentInChildren<Button>();
                    button.onClick.AddListener(SubmitChoices);
                    promptText.text = p.sPromptTitle;
                    break;
                case 2:
                    createdPanel = (GameObject)Instantiate(dropdown2Panel, transform);
                    createdPanel.transform.position = new Vector3(0, 0, 0);
                    createdPanel.transform.localPosition = new Vector3(0, 0, 0);
                    textComponents = GetComponentsInChildren<Text>();
                    promptText = textComponents[0];
                    dropdowns = GetComponentsInChildren<Dropdown>();
                    button = GetComponentInChildren<Button>();
                    button.onClick.AddListener(SubmitChoices);
                    promptText.text = p.sPromptTitle;
                    break;
                case 3:
                    createdPanel = (GameObject)Instantiate(dropdown3Panel, transform);
                    createdPanel.transform.position = new Vector3(0, 0, 0);
                    createdPanel.transform.localPosition = new Vector3(0, 0, 0);
                    textComponents = GetComponentsInChildren<Text>();
                    promptText = textComponents[0];
                    dropdowns = GetComponentsInChildren<Dropdown>();
                    button = GetComponentInChildren<Button>();
                    button.onClick.AddListener(SubmitChoices);
                    promptText.text = p.sPromptTitle;
                    break;
                default: break;
            }
        }
        public void SubmitChoices()
        {
            if(promptText.text == "Enter the address to connect to")
            {
                jndp.connect(answerText.text);
            }
            else
            {
                string writeString = "";
                foreach (Dropdown d in dropdowns)
                {
                    writeString += d.options[d.value].text.ToString() + ",";
                    Debug.Log("Added " + d.options[d.value].text.ToString() + " to output");
                }
                Debug.Log("Writestring: " + writeString);
                jndp.write(writeString + "\n");
            }
            Destroy(createdPanel);
            createdPanel = null;
        }
    }
}