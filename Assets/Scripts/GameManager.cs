using UnityEngine;
using System;
using System.Net;
using Random = UnityEngine.Random;
using System.Collections;
using Assets.Scripts;

public class GameManager : MonoBehaviour {
    public Campaign activeCampaign = new Campaign();
    PromptWindowManager promptWindowManager;
    Canvas promptWindowCanvas;
    public Hero clientHero;
    Boolean bClientIsDM;
    public JavaNetworkDungeonsProtocol jndp;
	// Use this for initialization
	void Start () {
        promptWindowManager = GetComponentInChildren<PromptWindowManager>();
        jndp = new JavaNetworkDungeonsProtocol(promptWindowManager);
    }
	
	// Update is called once per frame
	void Update () {
        jndp.update();
	}
}