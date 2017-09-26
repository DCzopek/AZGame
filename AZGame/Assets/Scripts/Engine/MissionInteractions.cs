using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInteractions : MonoBehaviour {

    AdventureManager adventureManager;

    BattleController battleController;

    private void Awake()
    {
        adventureManager = FindObjectOfType<AdventureManager>();

        battleController = FindObjectOfType<BattleController>();
    }
    public void SetNextPart()
    {
        adventureManager.LoadMissionData();
    }
    public void CharacterAction(string damageType)
    {
        battleController.DealDamageToEnemy(damageType);
    }
}
