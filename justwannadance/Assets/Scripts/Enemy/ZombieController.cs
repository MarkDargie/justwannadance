using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : EnemyBase
{

    // Start is called before the first frame update
    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("TAKE DAMAGE: " + damage);
        if(currentHealth < 0)
        {
            // die
        }
    }

    public override void Update()
    {
        //test
    }
}
