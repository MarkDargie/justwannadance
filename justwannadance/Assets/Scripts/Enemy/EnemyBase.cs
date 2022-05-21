using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

    private Animator animator;
    protected PlayerCombat playerManager;

    [Header("Stats")]
    public float maxHealth;
    public float currentHealth;
    public float basicAttackDamage;
    public float lookRadius = 10f;

    [Header("Movement")]
    public float movementSpeed;

    // Start is called before the first frame update
    protected abstract void Start();

    // Update is called once per frame
    public abstract void Update();

    public abstract void TakeDamage(float damageAmount);

    public abstract void BasicAttack();

    public void Die()
    {
        // disable enemy
        // die animation trigger
    }

}
