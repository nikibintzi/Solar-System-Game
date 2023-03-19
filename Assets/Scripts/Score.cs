using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    public Text txt;
    public int points;


    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }
    
    public void Awake()
    {
        instance = this;
    }
   

    public void AddPoints()
    {
        points +=1;
        txt.text = "SCORE: "+points.ToString();
        if (points == 6)
        {
            txt.text = " ALL PLANETS DESTROYED! YOU WON :) PRESS Q TO EXIT";
        }
    }
}
