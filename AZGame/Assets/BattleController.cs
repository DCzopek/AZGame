using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public Button meleeAttack, distanceAttack, magicAttack;

    

    public GameObject missionBackground;
    public GameObject battleground;
    public Enemy enemy;
    public Player player;


    TextFieldsUpdate textFieldsUpdater;

    

    private void Awake()
    {
        textFieldsUpdater = FindObjectOfType<TextFieldsUpdate>();
    }
    public void StartBattle()
    {
        RandomizeMonster(); 
        LoadBattleground();
    }
    void LoadBattleground()
    {
        missionBackground.SetActive(false);
        battleground.SetActive(true);
    }
    public void LoadMissionBoard()
    {
        battleground.SetActive(false);
        missionBackground.SetActive(true);
    }
    void RandomizeMonster()
    {
        // test
        //GDEManager.currentMonster = GDEManager.monstersList[0];
        // default
        GDEManager.currentMonster = GDEManager.monstersList[Random.Range(0, GDEManager.monstersList.Count - 1)];
        textFieldsUpdater.UpdateEnemyHealth(GDEManager.currentMonster.HealthPoints);
        textFieldsUpdater.enemyName.text = GDEManager.currentMonster.MonsterName;
    }
    public void UpdateEnemyHealth(float healthPoints)
    {
        textFieldsUpdater.UpdateEnemyHealth(healthPoints);
    }
    public void UpdatePlayerHealth()
    {
        textFieldsUpdater.UpdatePlayerHealth();
    }
    public void DealDamageToEnemy(string damageType)
    {
        float damageValue = GetValueFromDamageType(damageType);
        enemy.GetDamage(damageValue);
    }
    float GetValueFromDamageType(string damageType)
    {
        switch (damageType)
        {
            case "meleeAttack":
                return GDEManager.character.basicMelee;
            case "distanceAttack":
                return GDEManager.character.basicDistance;
            case "magicAttack":
                return GDEManager.character.basicMagic;
            default:
                return 0;
        }
    }
    public void EndPlayerTurn()
    {
        meleeAttack.interactable = false;
        distanceAttack.interactable = false;
        magicAttack.interactable = false;
    }
    public void StartEnemyTurn()
    {
        enemy.StartTurn();
    }
    public void DealDamageToPlayer(float damage)
    {
        player.GetDamage(damage);
    }
    public void StartPlayerTurn()
    {
        meleeAttack.interactable = true;
        distanceAttack.interactable = true;
        magicAttack.interactable = true;
    }
}
