using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //stats
    public float maxHealth = 10f;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageTaken)
    {
        Debug.Log("Player TakeDamage(): " + damageTaken);
        currentHealth -= damageTaken;
        if(currentHealth < 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }

}
