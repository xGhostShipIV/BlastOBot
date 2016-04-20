using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public GameObject particle;

    public AudioSource explosion;
    public AudioSource dying;

    public float moveSpeed;

    public bool isAlive;

    private float deathTimer = 0;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        particle = GetComponentInChildren<ParticleSystem>().gameObject;
        particle.SetActive(false);
	}
	
    public void Init()
    {
        //Generate position in sphere around player
        Vector3 position = Random.insideUnitSphere * Random.Range(20.0f, 50.0f);
        position.y = Random.Range(1.0f, 3.0f);

        gameObject.transform.position = position;
        gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
        gameObject.SetActive(true);

        particle.SetActive(false);

        isAlive = true;
        deathTimer = 0;
    }

	// Update is called once per frame
	void Update () {

        if (isAlive)
        {
            Vector3 travelVector = (player.transform.position - new Vector3(0, 1.5f, 0) - gameObject.transform.position);
            gameObject.transform.position += travelVector.normalized * moveSpeed;

            if (travelVector.magnitude < 1.0f)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (deathTimer > 3.0f)
            {
                gameObject.SetActive(false);
            }
            else deathTimer += Time.deltaTime;
        }
	}

    public void onDeath()
    {
        isAlive = false;
        particle.SetActive(true);
        GetComponentInChildren<Animator>().Play("Die");

        explosion.Play();
        dying.Play();
    }
}
