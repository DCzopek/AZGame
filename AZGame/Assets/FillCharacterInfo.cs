using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillCharacterInfo : MonoBehaviour {

    public Text meleeAttack;
    public Text distanceAttack;
    public Text magicAttack;
    public Text healthPoints;

    private void Awake()
    { 
        FillInfo();
    }
    void FillInfo()
    {
        healthPoints.text = "Health: " + GDEManager.character.health;
        meleeAttack.text = "Melee " + GDEManager.character.basicMelee;
        distanceAttack.text = "Distance " + GDEManager.character.basicDistance;
        magicAttack.text = "Magic " + GDEManager.character.basicMagic;
    }
}
