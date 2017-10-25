using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    public float speed = 10;
    public int damage;
    public GameObject target;
	public Vector3 startPosition;
	public Vector3 targetPosition;

    private float distance;
    private float startTime;
	private game_manager gm;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition);
		gm = GameObject.Find ("GameManager").GetComponent<game_manager> ();
    }

    private void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        // 2 
        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
				Transform healthBarTransform = target.transform.Find("HealthBar");
				HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
				healthBar.currentHealth = healthBar.currentHealth - 30;
				healthBar.Hit ();

				gm.AddScore (7);

                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
					gm.AddCash (5);
					if (!gm.CheckEnemiesAlive (1)) {
						gm.StartCountDown ();
					}
                }
            }
            Destroy(gameObject);
        }
    }
    // 1 
    
	
	// Update is called once per frame
	/*void FixedUpdate () {
        float timeInterval = Time.time - startTime;
		gameObject.transform.position = Vector2.MoveTowards (startPosition, targetPosition, timeInterval * speed / distance);
        
		if (gameObject.transform.position.x == targetPosition.x) 
        {
            if (target != null)
            {
            }
            Destroy(gameObject);
        }
    }*/
}
