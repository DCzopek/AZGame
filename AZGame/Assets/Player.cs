using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public void GetDamage(float damage)
    {
        GDEManager.character.health -= damage;
    }
}
