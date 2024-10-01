using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quai : MonoBehaviour
{
    public float VanTocVat;
    public bool DiChuyenTrai = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 DiChuyen = transform.localPosition;
        if (DiChuyenTrai) DiChuyen.x -= VanTocVat * Time.deltaTime;
        else DiChuyen.x += VanTocVat * Time.deltaTime;
        transform.localPosition = DiChuyen;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player" && collision.contacts[0].normal.x > 0)
        {
            DiChuyenTrai = false;
            QuayMat();
        }
        else if(collision.collider.tag != "Player" && collision.contacts[0].normal.x < 0)
        {
            DiChuyenTrai = true;
            QuayMat();
        }
        
    }
    void QuayMat()
    {
        Vector2 HuongQuay = transform.localScale;
        HuongQuay.x *=-1;
        transform.localScale = HuongQuay;
    }
}
