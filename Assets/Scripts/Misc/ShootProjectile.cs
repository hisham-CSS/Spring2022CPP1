using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShootProjectile : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;


    public AudioClip fireSFX;
    public AudioMixerGroup soundFXMixer;
    public Transform projectileSpawnPointLeft;
    public Transform projectileSpawnPointRight;
    public float projectileSpeed;
    public Projectile projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (projectileSpeed <= 0)
            projectileSpeed = 7.0f;

        if (!projectileSpawnPointLeft || !projectileSpawnPointRight || !projectilePrefab)
            Debug.LogWarning("Issue with inspector values");
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClip = anim.GetCurrentAnimatorClipInfo(0);
        if (curPlayingClip.Length > 0)
        {
            if (Input.GetButtonDown("Fire1") && curPlayingClip[0].clip.name != "Fire" && curPlayingClip[0].clip.name != "Lookup")
                 anim.SetTrigger("Fire");
        }
    }

    void Fire()
    {
        if (!sr.flipX)
        {
            Projectile curProjectile = Instantiate(projectilePrefab, projectileSpawnPointRight.position, projectileSpawnPointRight.rotation);
            curProjectile.speed = projectileSpeed;
        }
        else
        {
            Projectile curProjectile = Instantiate(projectilePrefab, projectileSpawnPointLeft.position, projectileSpawnPointLeft.rotation);
            curProjectile.speed = -projectileSpeed;
        }

        GameManager.instance.playerInstance.GetComponent<ObjectSounds>().Play(fireSFX, soundFXMixer);

        //Debug.LogError("Pause");
    }
}
