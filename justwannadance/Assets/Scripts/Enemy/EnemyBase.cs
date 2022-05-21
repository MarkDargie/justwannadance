using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

    private Animator animator;

    [Header("Stats")]
    public float maxHeelth;
    public float currentHealth;
    public float damageAmount;

    [Header("Movement")]
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHeelth;
    }

    // Update is called once per frame
    public abstract void Update();

    public abstract void TakeDamage(float damage);

    public void Die()
    {
        // disable enemy
        // die animation trigger
    }

}
