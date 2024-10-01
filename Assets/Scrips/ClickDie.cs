using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDie : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject click;
    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}
