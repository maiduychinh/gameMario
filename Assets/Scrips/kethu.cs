using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kethu : MonoBehaviour
{
    GameObject Mario;
    private void Awake()
    {
        Mario = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.tag == "Player" && (collision.contacts[0].normal.x > 0 || collision.contacts[0].normal.x < 0))
        {
            SceneManager.LoadScene("batdau");
        }
    }
}
