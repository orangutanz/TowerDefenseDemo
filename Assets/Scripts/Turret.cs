using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float damage = 10.0f;
    public float range = 10.0f;
    public float fireRate = 2.0f;

    private GameObject currentTarget = null;

    public GameObject muzzle;
    public GameObject turretHead;
    public GameObject bulletPrefab;

    //public ParticleSystem muzzleflash;

    private float nextTimeToFire = 0.0f;
    private float dividedFireRate = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //GizmoDrawer gd = GetComponent<GizmoDrawer>();
        //gd.radius = range;
        //gd.showGizmo = true;
        dividedFireRate = 1.0f / fireRate;
        //muzzleflash.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateTarget();

        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + dividedFireRate;
            Shoot();
        }
    }

    void UpdateTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        GameObject target = GetClosestTarget(enemies);

        if (target != null)
        {
            if ((target.transform.position - muzzle.transform.position).sqrMagnitude < range * range)
            {
                currentTarget = target;
                turretHead.transform.LookAt(currentTarget.transform);
            }
        }
        else
        {
            currentTarget = null;
        }
    }

    GameObject GetClosestTarget(Enemy[] enemies)
    {
        GameObject retEnemy = null;
        for (int i = 0; i < enemies.Length; ++i)
        {
            if (enemies[i].GetHealth() > 0.0f)
            {
                if (retEnemy == null)
                {
                    retEnemy = enemies[i].gameObject;
                }
                else if ((enemies[i].transform.position - muzzle.transform.position).sqrMagnitude < (retEnemy.transform.position - muzzle.transform.position).sqrMagnitude)
                {
                    retEnemy = enemies[i].gameObject;
                }
            }
        }
        return retEnemy;
    }


    private void Shoot()
    {
        if (currentTarget != null)
        {
            //muzzleflash.Play();
            currentTarget.GetComponent<Enemy>().TakeDamage(damage);
            GameObject bulletObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

}
