using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class chet : MonoBehaviour
{
    public int health;
    public bool hasDied;
    // Start is called before the first frame update
    void Start()
    {
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -36)
        {
            hasDied = true;
        }
        if (hasDied == true)
        {
            StartCoroutine("Die");
        }
    }
    IEnumerator Die()
    {
        SceneManager.LoadScene("batdau");
        yield return null;
    }

}
