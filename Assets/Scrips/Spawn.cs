using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] enemis;
    public Transform spawn;
    private int rand;

    public float start;
    private float time;
    private void Start()
    {
        time = start;
    }
    private void Update()
    {
        if(time <= 0)
        {
            rand = Random.Range(0, enemis.Length);
            Instantiate(enemis[rand], spawn.transform.position, Quaternion.identity);
            time = start;
        }
        else
        {
            time -=Time.deltaTime;
        }
    }
}
