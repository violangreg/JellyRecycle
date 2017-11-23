using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBottleGenerator : MonoBehaviour
{

    public Transform generationPoint;
    public GameObject cola;
    //public ObjectPooler objectPool;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("spawnBottle", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void update()
    {
        spawnBottle();
    }

    void spawnBottle()
    {
        Instantiate(cola, new Vector3(Random.Range(-5, 5), 0), cola.transform.rotation);
    }

}