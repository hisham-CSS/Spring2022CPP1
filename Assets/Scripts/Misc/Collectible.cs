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
