using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : EnemyBase
{

    Transform target;
    NavMeshAgent agent;

    public float basicAttackCooldown;

    protected override void Start()
    {
        currentHealth = maxHealth;
        target = PlayerManager.instance.player.transform;
        playerManager = PlayerManager.instance.player.GetComponent<PlayerCombat>();
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("Enemy Target " + target);
        agent.speed = 3;
    }

    public override void Update()
    {
        basicAttackCooldown -= Time.deltaTime;

        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                // attack
                BasicAttack();
                FaceTarget();
            }

        }
    }

    public override void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        //Debug.Log("TAKE DAMAGE: " + damageAmount);
        if (currentHealth < 0)
        {
            // die
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public override void BasicAttack()
    {
        if(basicAttackCooldown <= 0f)
        {
            Debug.Log("zombie attacking");
            playerManager.TakeDamage(basicAttackDamage);
        }
    }
}
