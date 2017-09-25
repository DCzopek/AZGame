using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInteractions : MonoBehaviour {

    AdventureManager adventureManager;

    private void Awake()
    {
        adventureManager = FindObjectOfType<AdventureManager>();
    }
    public void SetNextPart()
    {
        adventureManager.LoadMissionData();
    }
}
