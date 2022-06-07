using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        POWERUP,
        LIFE
    }

    public CollectibleType curCollectible;
    public AudioClip pickupSound;
    public AudioMixerGroup soundFXGroup;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.playerInstance.GetComponent<ObjectSounds>().Play(pickupSound, soundFXGroup);
            switch (curCollectible)
            {
                case CollectibleType.LIFE:
                    GameManager.instance.lives++;
                    break;
                case CollectibleType.POWERUP:
                    GameManager.instance.playerInstance.StartJumpForceChange();
                    break;
            }

            Destroy(gameObject);
        }
    }
}
