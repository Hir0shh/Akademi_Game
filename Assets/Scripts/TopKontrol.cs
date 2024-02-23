using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    public Button btn;
    private Rigidbody rb;
    public float Hiz = 3f;
    public Text zaman, can,durum;
    float zamanSayaci = 500;
    float canSayaci = 20;
    bool oyunDevam = true;
    bool OyunTamam = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (oyunDevam&&!OyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        else if(!OyunTamam)
        {
            durum.text = "Oyun Tamamlanamadı.";
            btn.gameObject.SetActive(true);
        }
        if (zamanSayaci < 0)
        {
            oyunDevam = false;
        }
    }

    void FixedUpdate()
    {
        if (oyunDevam&&!OyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(yatay, 0, dikey);
            rb.AddForce(kuvvet * Hiz);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
    }
    private void OnCollisionEnter(Collision other)
    {
        string objeIsmi = other.gameObject.name;
        if (objeIsmi.Equals("Finish"))
        {
            //print("oyunu kazandiniz.");
            OyunTamam = true;
            durum.text = "Oyun tamamlandı Tebrikler.";
            btn.gameObject.SetActive(true);
        }
        else if(!objeIsmi.Equals("AnaZemin")&& !objeIsmi.Equals("LabirentZamin") && !objeIsmi.Equals("Start"))
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            if (canSayaci == 0)
            {
                oyunDevam = false;
            }
        }
    }
}
