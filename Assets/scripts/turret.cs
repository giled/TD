using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private Transform target;
    public Enemy targetEnemy;
    [Header("General")]


    public float range = 15f;
    [Header("Use bullets(default)")]
    public GameObject bulletPrefab;

    public float fireRate=1f;
    private float firecountdow = 0f;
    [Header("Use Laser")]

    public int damageOverTime = 30;
    public float slowPct = .5f;

    public bool useLaser = false;
    public LineRenderer lineRender;
    public ParticleSystem ImpactEffect;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform PartToRotate;
    public float turnSpeed = 10f;
   
    public Transform firePoint;


    // Use this for initialization
    void Start(){
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)

        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distancetoEnemy < shortestDistance)
            {
                shortestDistance = distancetoEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update() {

        if (target == null)
        {
            if (useLaser)
            {
                if (lineRender.enabled)
                {
                    lineRender.enabled = false;
                    ImpactEffect.Stop();
                }
                  
            }
            return;
        }
        //targe lock
        LockOnTarget();
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (firecountdow <= 0)
            {
                Shoot();
                firecountdow = 1f / fireRate;
            }
            firecountdow -= Time.deltaTime;
        }

    }
   
   void LockOnTarget()
    {

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Laser()
    {

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
       targetEnemy.Slow(slowPct);
        
        
        if (!lineRender.enabled)
        {
            lineRender.enabled = true;
            ImpactEffect.Play();

        }


        lineRender.SetPosition(0, firePoint.position);
        lineRender.SetPosition(1, target.position);
        Vector3 dir = firePoint.position - target.position;
        ImpactEffect.transform.position = target.position+dir.normalized*.5f ;
        ImpactEffect.transform.rotation = Quaternion.LookRotation(dir);

        
    }
    void Shoot()
    {
       GameObject bulletGO=(GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);
    }
}
