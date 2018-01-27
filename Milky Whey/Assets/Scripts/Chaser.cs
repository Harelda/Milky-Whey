using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour {
    public float lowerMovementSpeed;
    public float upperMovementSpeed;
    public bool isPlebChaser;

    private float movementSpeed;
    private GameObject lockOn = null;
    private Rigidbody2D rb2d;
    private ParticleSystem particle;
    private bool deathStart;

	// Use this for initialization
	private void Awake()
    {
        movementSpeed = Random.Range(lowerMovementSpeed, upperMovementSpeed);
        rb2d = GetComponent<Rigidbody2D>();
        particle = GetComponent<ParticleSystem>();
        deathStart = false;
	}

    private void Start()
    {
        if (isPlebChaser)
        {

            lockOn = findClosestActiveResourcePlanet();
        }

        if (lockOn == null)
        {
            lockOn = GameObject.Find("Player Objects");
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb2d.MovePosition(Vector3.MoveTowards(transform.position, lockOn.transform.position, movementSpeed * Time.deltaTime));
	}

    public GameObject findClosestActiveResourcePlanet()
    {
        GameObject[] planets;
        GameObject cloesetPlanet = null;
        Vector3 diff;
        float curDistance;

        planets = GameObject.FindGameObjectsWithTag("ResourcePlanet");
        float distance = Mathf.Infinity;

        foreach (GameObject planet in planets)
        {
            if (planet.GetComponent<ResourcePlanet>().isTowerActivated)
            {
                diff = planet.transform.position - transform.position;
                curDistance = diff.sqrMagnitude;

                if (curDistance < distance)
                {
                    cloesetPlanet = planet;
                    distance = curDistance;
                }
            }
        }

        return cloesetPlanet;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "ResourcePlanet")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            particle.Play();

            Destroy(gameObject, 1.5f);
        }

        if (collision.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }
}
