using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFieldsUpdate : MonoBehaviour {

    public Text meleeAttack;
    public Text distanceAttack;
    public Text magicAttack;
    public Text healthPoints;
    public Text enemyHealthPoints;
    public Text enemyName;

    private void Awake()
    { 
        FillInfo();
    }
    public void FillInfo()
    {
        UpdatePlayerHealth();
        meleeAttack.text = "Melee " + GDEManager.character.basicMelee;
        distanceAttack.text = "Distance " + GDEManager.character.basicDistance;
        magicAttack.text = "Magic " + GDEManager.character.basicMagic;
    }
    public void UpdatePlayerHealth()
    {
        healthPoints.text = "Health: " + GDEManager.character.health;
    }
    public void UpdateEnemyHealth(float value)
    {
        enemyHealthPoints.text = "Health: " + value;
    }
}
