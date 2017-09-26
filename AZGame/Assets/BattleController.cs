using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public Text enemyHealthPoints;

    public GameObject missionBackground;
    public GameObject battleground;
    public Enemy enemy;

    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();

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
    void RandomizeMonster()
    {
        // test
        GDEManager.currentMonster = GDEManager.monstersList[0];
        enemyHealthPoints.text = "Health: " + GDEManager.currentMonster.HealthPoints;
        // default
        //GDEManager.currentMonster = GDEManager.monstersList[Random.Range(0, GDEManager.monstersList.Count - 1)];
    }
    public void UpdateEnemyInfo(float value)
    {
        enemyHealthPoints.text = "Health: " + value;
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
    


}
