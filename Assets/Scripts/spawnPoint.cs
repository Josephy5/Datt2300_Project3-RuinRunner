using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(obstacle, transform.position, quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
