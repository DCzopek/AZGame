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
        battleController.UpdateEnemyInfo(healthPoints);
    }
}
