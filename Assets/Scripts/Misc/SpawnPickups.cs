using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public Collectible[] collectiblePrefabArray;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(collectiblePrefabArray[0], transform.position, transform.rotation);   
    }
}
