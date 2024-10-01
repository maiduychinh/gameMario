using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MriOScript : MonoBehaviour
{
    private float VanToc = 7;
    private float VanTocToiDa = 12f;    //Van toc max khi giu Z
    private float TocDo = 5f;            //Toc do cua mario
    private bool DuoiDat = true;         //Kiem tra mario co o duoi dat khong
    private float NhayCao = 400;                //Lay toc do nhay cua mario
    private float NhayThap = 3;               //Ap dung khi mario nhay thap,nhan nhanh va buong phim X.
    private float RoiXuong = 5;               //Luc hut roi xuong
    private bool QuayPhai=true;          //Kiem tra xem mario quay ve huong nao
    private float KTGiuPhim = 0.2f;
    private float TGGiuPhim = 0;

    private int Coin, Thong;
    public Text TCoin, TThong;
    private Rigidbody2D r2d;
    private Animator HoatHoa;


    private AudioSource AmThanh;

    private Vector2 ViTriChet;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        HoatHoa = GetComponent<Animator>();
        AmThanh = GetComponent<AudioSource>();
        Coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HoatHoa.SetFloat("TocDo",TocDo);
        HoatHoa.SetBool("DuoiDat",DuoiDat);
        NhayLen();
        BanDanVaTangToc();
    }
    private void FixedUpdate()
    {
        DiChuyen();
    }
    void DiChuyen()
    {
        // chon phim di chuyen mario trai <-,phai->
        float PhimNhanPhaiTrai = Input.GetAxis("Horizontal");
        r2d.velocity=new Vector2 (VanToc * PhimNhanPhaiTrai, r2d.velocity.y);
        TocDo = Mathf.Abs(VanToc * PhimNhanPhaiTrai);
        if (PhimNhanPhaiTrai > 0 && !QuayPhai) HuongMatMario();
        if (PhimNhanPhaiTrai < 0 && QuayPhai) HuongMatMario();

    }
    void HuongMatMario()
    {
        // Neu Mario Khong quay phai thi
        QuayPhai = !QuayPhai;
        Vector2 HuongQuay = transform.localScale;
        HuongQuay.x *= -1;
        transform.localScale = HuongQuay;
    }
    void NhayLen()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && DuoiDat == true)
        {
            r2d.AddForce((Vector2.up) * NhayCao);
            TaoAmThanh("MarioNhay");
            DuoiDat = false;
        }
        // AD trong luc Cho Mario - Roi nhanh hon
        if (r2d.velocity.y < 0)
        {
            r2d.velocity += Vector2.up * Physics2D.gravity.y * (RoiXuong - 1) * Time.deltaTime;
        }
        else if (r2d.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
        {
            r2d.velocity += Vector2.up*Physics2D.gravity.y * (NhayThap - 1) * Time.deltaTime;
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NenDat")
        {
            DuoiDat = true;
        }
        if(collision.tag == "Coin")
        {
            Coin++;
            TCoin.text = Coin.ToString();
        }
        if(collision.tag == "Thong")
        {
            Thong++;
            TThong.text = Thong.ToString();
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "NenDat")
        {
            DuoiDat = true;
        }


    }
    //Ban dan va chay nhanh hon
    void BanDanVaTangToc()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            TGGiuPhim +=Time.deltaTime;
            if (TGGiuPhim < KTGiuPhim)
            {
                print("Ban dan");
            }
            else
            {
                VanToc = VanToc * 1.01f;
                if(VanToc > VanTocToiDa) VanToc = VanTocToiDa;
            }

        }
        if (Input.GetKeyUp(KeyCode.Z)){
            VanToc = 7f;
            TGGiuPhim = 0;
        }
    }
    public void TaoAmThanh(string FileAmThanh)
    {
        AmThanh.PlayOneShot(Resources.Load<AudioClip>("Audio/" + FileAmThanh));
    }
    public void MarioChet()
    {
        ViTriChet = transform.localPosition;
        GameObject MarioChet = (GameObject)Instantiate(Resources.Load("Graphics/Lep-hd"));
        MarioChet.transform.localPosition=ViTriChet;
        Destroy(MarioChet);
        StartCoroutine(HMariochet());
    }
    IEnumerator HMariochet()
    {
        float TocDoNay = 2.5f;
        float DoNayCao = 2f;
        while (true)
        {

            transform.localPosition=new Vector2(transform.localPosition.x, transform.localPosition.y+TocDoNay*Time.deltaTime);
            if (transform.localPosition.y >= ViTriChet.y + DoNayCao + 1)
            break;
            yield return null;

            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - TocDoNay * Time.deltaTime);
            if (transform.localPosition.y <= -10f)
            {     
                Destroy(gameObject);
                break;
            }
            yield return null;

        }

    }
  
}
