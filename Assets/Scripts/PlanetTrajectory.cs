using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlanetTrajectory : MonoBehaviour
{
    public GameObject Sun;
    public float velocity;

    public void Start()
    {
        
    }
    
    public void Update()
    {
        if (Sun != null)
        {
            //Orbit at distance
            transform.RotateAround(Sun.transform.position, Vector3.up, velocity * Time.deltaTime);
        }
    }
}