using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthPoints;
    public float meleeDamage;
    public float distanceDamage;
    public float magicDamage;

    BattleController battleController;

    float specialAbilityPoints = 0f;

    private void Awake()
    {
        battleController = FindObjectOfType<BattleController>();
        SetValues();
    }
    void SetValues()
    {
        healthPoints = GDEManager.currentMonster.HealthPoints;
        meleeDamage = GDEManager.character.basicMelee;
        distanceDamage = GDEManager.character.basicMelee;
        magicDamage = GDEManager.character.basicMagic;
    }
    public void GetDamage(float damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0f)
        {
            battleController.LoadMissionBoard();
            return;
        }
        battleController.UpdateEnemyHealth(healthPoints);
    }
    public void StartTurn()
    {
        float maxDamageValue = GetMaxDamageValue(GetMaxDamageValue(meleeDamage,magicDamage), distanceDamage);

        specialAbilityPoints += GDEManager.currentMonster.SpecialAbilityAdditive;

        //if(specialAbilityPoints >= 0.8f)
            //TODO run special ability
        
        
        battleController.DealDamageToPlayer(maxDamageValue);

        battleController.StartPlayerTurn();
    }
    float GetMaxDamageValue(float val1, float val2)
    {
        return (val1 > val2) ? val1 : val2;
    }
}
