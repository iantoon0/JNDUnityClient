using UnityEngine;
using System;
using System.Net;
using Random = UnityEngine.Random;
using System.Collections;
using Assets.Scripts;

public class GameManager : MonoBehaviour {
    public Campaign activeCampaign;
    PromptWindowManager promptWindowManager;
    public Hero clientHero;
    Boolean bClientIsDM;
    int iterator;
    public JavaNetworkDungeonsProtocol jndp;
	// Use this for initialization
	void Start () {
        promptWindowManager = GetComponentInChildren<PromptWindowManager>();
        jndp = GetComponent<JavaNetworkDungeonsProtocol>();
    }
	
	// Update is called once per frame
	void Update () {
        jndp.update();
        if(iterator == 50)
        {
            iterator = 0;
        }
        iterator++;
	}
}