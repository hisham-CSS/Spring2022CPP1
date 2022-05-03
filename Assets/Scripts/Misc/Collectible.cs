using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        POWERUP,
        LIFE
    }

    public CollectibleType curCollectible;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController curPlayer = collision.gameObject.GetComponent<PlayerController>();

            switch (curCollectible)
            {
                case CollectibleType.LIFE:
                    curPlayer.lives++;
                    break;
                case CollectibleType.POWERUP:
                    curPlayer.StartJumpForceChange();
                    break;
            }

            Destroy(gameObject);
        }
    }
}
