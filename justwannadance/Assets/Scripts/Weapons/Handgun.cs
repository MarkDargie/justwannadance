using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SHOULD BE BASE WEAPON CLASS
public class Handgun : WeaponBase
{

    [SerializeField] Transform aimPoint;
    [SerializeField] LineRenderer lineRenderer;
    private bool canFire = true;

    Ray ray;
    //RaycastHit rHit;

    protected override void Start()
    {

    }


    // Update is called once per frame
    protected override void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("can fire: " + canFire);
            StartCoroutine(Shoot());
        }

        ray = camera.ScreenPointToRay(Input.mousePosition);

    }

     IEnumerator Shoot()
    {
        // raycast firing
        RaycastHit hit;
        Debug.Log("FIRE");
        canFire = false;
        //StartCoroutine(Cooldown());
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {

            EnemyBase target = hit.transform.GetComponent<EnemyBase>();
            Vector3 forward = camera.transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(camera.transform.position, forward, Color.green);

            if (target != null)
            {
                if (hit.collider is SphereCollider) // if headshot
                {
                    target.TakeDamage(weaponDamage + headshotMultiplier);
                }
                else
                {
                    target.TakeDamage(weaponDamage);
                }
            }

            lineRenderer.SetPosition(0, aimPoint.transform.position);
            lineRenderer.SetPosition(1, hit.point);

        }
        else
        {
            lineRenderer.SetPosition(0, aimPoint.transform.position);
            lineRenderer.SetPosition(1, aimPoint.transform.position + aimPoint.right * 100);
        }

        lineRenderer.enabled = true;
        yield return 0;
        lineRenderer.enabled = false;

    }


    protected override IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(fireRateCooldown);
        Debug.Log("Cooldown Finished");
        canFire = true;
    }
}
