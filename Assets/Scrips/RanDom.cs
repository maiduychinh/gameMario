using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanDom : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoint;
    
    private int rand;

    public float start;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = start;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= 0)
        {
            
        }
    }
}
