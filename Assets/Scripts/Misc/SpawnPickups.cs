using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public Collectible[] collectiblePrefabArray;

    // Start is called before the first frame update
    void Start()
    {
        int RandValue = Random.Range(0, collectiblePrefabArray.Length);

        Instantiate(collectiblePrefabArray[RandValue], transform.position, transform.rotation);   
    }
}
