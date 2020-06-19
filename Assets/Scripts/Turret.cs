using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy; 

    [Header("General")]

    public float range = 15f; 

    [Header("Use Bullets (Default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f; //fire one bullet each second
    private float fireCountdown = 0f;   //starts at 0 so we fire right away

    [Header("Use Laser")]
    public bool useLaser = false; 
    public LineRenderer lineRenderer; 
    public int damageOverTime = 30; 
    public float slowPct = 0.5f; 

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate; 

    public float turnSpeed = 10f; 

    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null&& shortestDistance <= range) {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>(); 
        } else {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) {
            if(useLaser) {
                if(lineRenderer.enabled){
                    lineRenderer.enabled = false;
                }
            }
            return;
        }
        LockOnTarget(); 

        if(useLaser) {
            Laser();
        }         
        else {
            if (fireCountdown <= 0f) {
                Shoot(); 
                fireCountdown = 1f/fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
      
    }

    void LockOnTarget() {

        //Rotate Turret Head
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir); 
        //Smooth the transition to our current rotation overtime with speed determined with turnspeed
        Vector3 rotation =  Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; 

        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f); 
    }

    void Laser () {
            targetEnemy.TakeDamage(damageOverTime * Time.deltaTime); 
            targetEnemy.Slow(slowPct); 

            if(!lineRenderer.enabled){
                lineRenderer.enabled = true;
            }
            lineRenderer.SetPosition(0, firePoint.position); 
            lineRenderer.SetPosition(1, target.position); 
    }

    void Shoot() {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet  = bulletGO.GetComponent<Bullet>();

        if(bullet !=null) {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
