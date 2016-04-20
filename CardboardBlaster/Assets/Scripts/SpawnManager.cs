using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public int MAX_ENEMIES = 1;

    public GameObject enemyPrefab;

    private List<GameObject> Enemies;
    private List<GameObject> activeEnemies;

    private float elapsedTime;
    private float timeToSpawn;

    public bool isActive = false;

	// Use this for initialization
	void Start () {

        //Create two lists to keep track of object pools
        Enemies = new List<GameObject>();

        //Instantiate all enemies and makes them inactive. Adding them to inactive pool
        for(int i = 0; i < MAX_ENEMIES; i++)
        {
            GameObject g = Instantiate(enemyPrefab);
            g.SetActive(false);
            Enemies.Add(g);
        }

        elapsedTime = 0;
        timeToSpawn = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {

        if (isActive)
        {
            if (elapsedTime >= timeToSpawn)
            {
                SpawnNewEnemy();
                elapsedTime = 0;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }
	}

    void SpawnNewEnemy()
    {
        GameObject g = null;

        //Get first idle enemy off list
        foreach(GameObject obj in Enemies)
        {
            if(!obj.activeSelf)
            {
                g = obj;
                break;
            }
        }

        if (g != null)
        {
            g.GetComponent<Enemy>().Init();
        }
        
    }
}
