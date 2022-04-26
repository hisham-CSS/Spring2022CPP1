using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float minXClamp = -2.08f;
    public float maxXClamp = 180.7f;

    void LateUpdate()
    {
        if (player)
        {
            Vector3 cameraTransform;

            cameraTransform = transform.position;

            cameraTransform.x = player.transform.position.x;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, minXClamp, maxXClamp);

            transform.position = cameraTransform;
        }
    }
}
