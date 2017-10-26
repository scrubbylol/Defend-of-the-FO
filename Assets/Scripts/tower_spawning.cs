using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_spawning : MonoBehaviour {

    public GameObject towerPrefab;
    private GameObject tower;
    Vector2 whereToSpawn;

	private game_manager gm;

    // Use this for initialization
    void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<game_manager> ();
	}
	
	// Update is called once per frame
	void Update () {
/*if (Input.GetMouseButtonDown(0))
        {
            //2
            if (canPlaceTower())
            {
                //3
                tower = (GameObject)
                  Instantiate(towerPrefab, transform.position, Quaternion.identity);

				gm.SubCash (30);
                // TODO: Deduct gold
            }
        }*/
    }
    void OnMouseUp()
    {
        //2
        if (canPlaceTower())
        {
            //3
            tower = (GameObject)
              Instantiate(towerPrefab, transform.position, Quaternion.identity);
            //4
            gm.SubCash(30);

            // TODO: Deduct gold
        }
    }

    private bool canPlaceTower()
    {
		return tower == null && gm.cash > 30;
    }
    
}
