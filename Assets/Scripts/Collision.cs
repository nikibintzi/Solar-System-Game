using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public GameObject chuncks;
    public GameObject fireworksShower;
    public Text score;
    public int points;

    public float planetSize = 1f;
    float planetsPivotDistance;
    Vector3 planetsPivot;

    public float explosionForce = 45f;
    public float explosionRadius = 3f;
    public float explosionUpward = 10f;

    // Use this for initialization
    void Start()
    {

        //calculate pivot distance
        planetsPivotDistance = planetSize * 2 / 2;
        //use this value to create pivot vector
        planetsPivot = new Vector3(planetsPivotDistance, planetsPivotDistance, planetsPivotDistance);

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Meteor" && this.gameObject.tag =="Sun")
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Meteor" && this.gameObject.tag == "Planet")
        {
            Score.instance.AddPoints();
            GameObject Firework = Instantiate(fireworksShower, transform.position, Quaternion.identity);
            fireworksShower.GetComponent<ParticleSystem>().Play();
            planetExplosion();
            meteorExplosion(other);
        }

    }

    public void planetExplosion()
    {

        gameObject.SetActive(false);

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    createFragment(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    public void meteorExplosion(Collider other)
    {
        Destroy(other.gameObject);

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    createFragment(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce((-explosionForce), (-transform.position), -explosionRadius, -explosionUpward);
            }
        }

    }

    void createFragment(int x, int y, int z)
    {
        GameObject fragment= Instantiate(chuncks, transform.position, transform.rotation) as GameObject;
        fragment.transform.position = transform.position + new Vector3(planetSize * x, planetSize * y, planetSize * z) - planetsPivot;
        fragment.transform.localScale = new Vector3(planetSize, planetSize, planetSize);
        Destroy(fragment, 5);
    }

    public void Awake()
    {

    }

}