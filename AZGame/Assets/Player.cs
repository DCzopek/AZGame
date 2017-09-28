using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    BattleController battleController;

    private void Awake()
    {
        battleController = FindObjectOfType<BattleController>();
    }
    public void GetDamage(float damage)
    {
        GDEManager.character.health -= damage;

        if(GDEManager.character.health <= 0f)
            //TODO loose battle

        battleController.UpdatePlayerHealth();

    }
    
}
