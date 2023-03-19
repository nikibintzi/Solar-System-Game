using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public GameObject planet;
    public float velocity;
  
    private void Start()
    {
     
    }
    void Update()
    {
        if (planet != null)
        {
            //rotation of planet around itself
            transform.RotateAround(planet.transform.position, planet.transform.up, velocity * Time.deltaTime);
        }
    }
}