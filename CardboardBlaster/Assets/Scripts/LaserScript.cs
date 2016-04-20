using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

    public GameObject player;
    public float moveSpeed;

    private float elapsedTime = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (elapsedTime <= 3)
        {
            gameObject.transform.position += gameObject.transform.forward * moveSpeed;
            elapsedTime += Time.deltaTime;
        }
        else
            Destroy(gameObject);
	}
    
    void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "Enemy")
        {
            Enemy e = col.gameObject.GetComponentInParent<Enemy>();

            if (e.isAlive)
            {
                e.onDeath();

                //ADD SCORE HERE:
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Shooting>().AddToScore(100);

                Destroy(gameObject);
            }
        }
    }
}
