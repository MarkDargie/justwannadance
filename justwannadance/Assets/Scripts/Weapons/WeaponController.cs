using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SHOULD BE BASE WEAPON CLASS
public class WeaponController : MonoBehaviour
{

    [SerializeField] Transform aimPoint;
    [SerializeField] LineRenderer lineRenderer;

    public float weaponDamage = 10f;
    public float range = 100f;

    public Camera camera;

    Ray ray;
    //RaycastHit rHit;

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }

        ray = camera.ScreenPointToRay(Input.mousePosition);

    }

    IEnumerator Shoot()
    {
        // raycast firing
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            EnemyBase target = hit.transform.GetComponent<EnemyBase>();
            Vector3 forward = camera.transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(camera.transform.position, forward, Color.green);
            if (target != null)
            {
                target.TakeDamage(weaponDamage);
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

}
