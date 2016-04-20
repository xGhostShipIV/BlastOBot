using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

    public GameObject laserPrefab;
    public int score = 0;

    public bool gameOn = false;
	// Use this for initialization
	void Start () {
        GetComponentInChildren<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (gameOn)
        {
            if (Cardboard.SDK.VRModeEnabled && Cardboard.SDK.Triggered)
            {
                GameObject g = Instantiate(laserPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            }
        }
        else
        {
            if (Cardboard.SDK.VRModeEnabled && Cardboard.SDK.Triggered)
            {
                gameOn = true;
                GameObject.Find("EnemySpawner").GetComponent<SpawnManager>().isActive = true;
                GameObject.Find("Title").SetActive(false);
                GetComponentInChildren<Canvas>().enabled = true;
                GetComponentInChildren<Text>().text = "Score: " + score;
            }
        }
	}

    public void AddToScore(int amount_)
    {
        score += amount_;
        GetComponentInChildren<Text>().text = "Score: " + score;
    }
}
