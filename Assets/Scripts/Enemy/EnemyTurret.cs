using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{
    [SerializeField] float projectileForce;
    [SerializeField] float projectileFireRate;

    float timeSinceLastFire;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public Projectile projectilePrefab;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        if (projectileFireRate <= 0)
            projectileFireRate = 2.0f;

        if (projectileForce <= 0)
            projectileForce = 7.0f;
    }

    public override void Death()
    {
        base.Death();

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("Fire"))
        {
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                anim.SetBool("Fire", true);
            }
        }
        
    }

    public void Fire()
    {
        timeSinceLastFire = Time.time;

        Projectile temp = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);

        temp.speed = -projectileForce;
    }

    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }
}
