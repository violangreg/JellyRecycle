using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items_Pool : MonoBehaviour {

    public GameObject waterbottle1, waterbottle2, waterbottle3, metal, newspaper, soda1, soda2;
    private List<GameObject> objs;

	// Use this for initialization
	void Start () {
        objs = new List<GameObject>();
        objs.Add(waterbottle1);
        objs.Add(waterbottle2);
        objs.Add(waterbottle3);
        objs.Add(metal);
        objs.Add(newspaper);
        objs.Add(soda1);
        objs.Add(soda2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject getRandomItem()
    {
        return objs[Random.Range(0,6)];
    }
}
