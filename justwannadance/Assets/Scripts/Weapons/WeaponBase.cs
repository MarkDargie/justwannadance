using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{

    [Header("Weapon Properties")]
    public float weaponDamage;
    public float range;
    public float headshotMultiplier;
    public float fireRateCooldown;

    public Camera camera;
    public Animator animator;

    //[SerializeField] Transform aimPoint;
    //[SerializeField] LineRenderer lineRenderer;

    // Start is called before the first frame update
    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();

    //protected abstract void LateUpdate();

   // protected abstract IEnumerator Shoot();

    protected abstract IEnumerator Cooldown();
}
