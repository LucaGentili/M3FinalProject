using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int hp = 5;

    public void TakeDamage(int damage)
    {
        this.hp = hp - damage;
    }

    public bool IsAlive()
    {
        return hp > 0;
    }

}
