using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ShootEnemies : MonoBehaviour {
    public List<GameObject> enemiesInRange;
    public GameObject bulletPrefab;
    private float lastShotTime;

    // Use this for initialization
    void Start () {
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lastShotTime > 0.3)
        {
            Shoot();
            lastShotTime = Time.time;
        }
        /*GameObject target = null;
        // 1
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = 10;
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        // 2
        if (target != null)
        {
            if (Time.time - lastShotTime > 2)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }
            // 3
            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(
                Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,
                new Vector3(0, 0, 1));
        }*/
    }

    void Shoot()
    {
        // 1 
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = new Vector3(0,0,0);
        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;

        // 2 
        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        BulletBehaviour bulletComp = newBullet.GetComponent<BulletBehaviour>();
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;
        
    }

    // 1
    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 2
        if (other.gameObject.tag.Equals("Enemy"))
        {
            
        }
    }
    // 3
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            
        }
    }
}
