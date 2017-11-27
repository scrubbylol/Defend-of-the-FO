using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tower_spawning : MonoBehaviour {

    //Tower Prefabs
    public GameObject wizard_towerPrefab;
    private GameObject wizard_tower;
    public GameObject archer_towerPrefab;
    private GameObject archer_tower;

    //Game Manager
    private game_manager gm;

    //Tower Type Selection
    public Button archer_button;
    public Button wizard_button;
    private Button archer_select;
    private Button wizard_select;
    private GameObject tower_select;

    // Use this for initialization

    void Awake () {
        gm = GameObject.Find("GameManager").GetComponent<game_manager>();
    }
	
	// Update is called once per frame
	void Update () {
    }
    private bool canPlaceTower()
    {
        return archer_tower == null && wizard_tower == null;
    }
    void OnMouseUp()
    {
           //2
        if (canPlaceTower())
        {
            //3
			
            archer_select = Instantiate(archer_button, new Vector2(-2,0), Quaternion.identity);
            wizard_select = Instantiate(wizard_button, new Vector2(2, 0), Quaternion.identity);
            
            tower_select = GameObject.Find("Tower_Canvas");
            archer_select.transform.SetParent(tower_select.transform);
            wizard_select.transform.SetParent(tower_select.transform);
            archer_select.onClick.AddListener(placeArcherTower);
            wizard_select.onClick.AddListener(placeWizardTower);

        }
        else if (canUpgradeArcherTower())
        {
            archer_tower.GetComponent<TowerData>().increaseLevel();
            Debug.Log("Leveled Up");
            if (archer_tower.GetComponent<TowerData>().levels.IndexOf(archer_tower.GetComponent<TowerData>().CurrentLevel) == 1)
            {
               gm.SubCash(100);
            }
            else if (archer_tower.GetComponent<TowerData>().levels.IndexOf(archer_tower.GetComponent<TowerData>().CurrentLevel) == 2)
            {
                gm.SubCash(200);
            }
            // TODO: Deduct gold
        }
        else if (canUpgradeWizardTower())
        {
            wizard_tower.GetComponent<TowerData>().increaseLevel();
            Debug.Log("Leveled Up");
            if (wizard_tower.GetComponent<TowerData>().levels.IndexOf(wizard_tower.GetComponent<TowerData>().CurrentLevel) == 1)
            {
                gm.SubCash(120);
            }
            else if (wizard_tower.GetComponent<TowerData>().levels.IndexOf(wizard_tower.GetComponent<TowerData>().CurrentLevel) == 2)
            {
                gm.SubCash(240);
            }
            // TODO: Deduct gold
        }
    }
    private void placeWizardTower()
    {
        Debug.Log("Test");
        //3
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        wizard_tower = (GameObject)
          Instantiate(wizard_towerPrefab, transform.position, Quaternion.identity);
        //4
        gm.SubCash(30);
        archer_select.GetComponentInChildren<Button>().enabled = false;
        archer_select.GetComponentInChildren<Image>().enabled = false;
        archer_select.GetComponentInChildren<Text>().enabled = false;
        wizard_select.GetComponentInChildren<Button>().enabled = false;
        wizard_select.GetComponentInChildren<Image>().enabled = false;
        wizard_select.GetComponentInChildren<Text>().enabled = false;
        //Destroy(archer_select);
        //Destroy(wizard_select);
        Debug.Log("Test2");
    }
    private void placeArcherTower()
    {
        Debug.Log("Test");
        //3
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        archer_tower = (GameObject)
          Instantiate(archer_towerPrefab, transform.position, Quaternion.identity);
        //4
        gm.SubCash(30);
        archer_select.GetComponentInChildren<Button>().enabled = false;
        archer_select.GetComponentInChildren<Image>().enabled = false;
        archer_select.GetComponentInChildren<Text>().enabled = false;
        wizard_select.GetComponentInChildren<Button>().enabled = false;
        wizard_select.GetComponentInChildren<Image>().enabled = false;
        wizard_select.GetComponentInChildren<Text>().enabled = false;
        Debug.Log("Test2");
    }
    
    private bool canUpgradeWizardTower()
    {
        if(wizard_tower != null)
        {
            TowerData towerData = wizard_tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.getNextLevel();
            if (nextLevel != null)
            {
                if (wizard_tower.GetComponent<TowerData>().levels.IndexOf(nextLevel) == 1 && gm.cash >= 100)
                {
                    return true;
                }
                else if (wizard_tower.GetComponent<TowerData>().levels.IndexOf(nextLevel) == 2 && gm.cash >= 200)
                {
                    return true;
                }
            }
        }
        return false;
    }
    private bool canUpgradeArcherTower()
    {
        if (archer_tower != null)
        {
            TowerData towerData = archer_tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.getNextLevel();
            if (nextLevel != null)
            {
                if (archer_tower.GetComponent<TowerData>().levels.IndexOf(nextLevel) == 1 && gm.cash >= 100)
                {
                    return true;
                }
                else if (archer_tower.GetComponent<TowerData>().levels.IndexOf(nextLevel) == 2 && gm.cash >= 200)
                {
                    return true;
                }
            }
        }
        
        return false;
    }

}
