using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_spawning : MonoBehaviour {

    public GameObject towerPrefab;
    private GameObject tower;
    Vector2 whereToSpawn;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //2
            if (canPlaceTower())
            {
                //3
                tower = (GameObject)
                  Instantiate(towerPrefab, transform.position, Quaternion.identity);

                // TODO: Deduct gold
            }
        }
    }

    private bool canPlaceTower()
    {
        return tower == null;
    }
    
}
