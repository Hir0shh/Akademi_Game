using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectableCount : MonoBehaviour
{
    public GameObject kamera;
    public Button replay,menu,nextlvl;
    public Text zaman, can,coin, durum,score,highscore;
    public int count;

    float zamanSayaci = 0;
    float canSayaci = 3;

    public bool oyunDevam = true;
    public bool OyunTamam = false;

    public GameObject chest;
    public GameObject Bonus;

    

    public AudioClip hurtSound;
    public AudioClip waterSplash;
    private void Awake()
    {

    }
    private void Start()
    {
        UpdateCount();
        can.text = canSayaci + "";
        //PlayerPrefs.DeleteAll();



    }
    private void Update()
    {
        if (oyunDevam && !OyunTamam)
        {
            this.GetComponent<PlayerControls>().enabled = true;
            this.GetComponent<PlayerController>().enabled = true;
            zamanSayaci += Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
            
        }
        else if (!oyunDevam || !OyunTamam)
        {
            this.GetComponent<PlayerControls>().enabled = false;
            this.GetComponent<PlayerController>().enabled = false;
            durum.text = "Oyun Tamamlanamadi.";
            replay.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
            
        }
        
        if (zamanSayaci < 0)
        {
            oyunDevam = false;
        }
        if (count == Collectables.total)
        {
            //print("oyunu kazandiniz.");
            this.GetComponent<PlayerControls>().enabled = false;
            this.GetComponent<PlayerController>().enabled = false;
            OyunTamam = true;

            if (SceneManager.GetActiveScene().name=="Level_1")
            {
                if (PlayerPrefs.GetFloat("zamanLVL1")==0)
                {
                    PlayerPrefs.SetFloat("zamanLVL1", zamanSayaci);
                }
                else if(PlayerPrefs.GetFloat("zamanLVL1") > zamanSayaci)
                {
                    PlayerPrefs.SetFloat("zamanLVL1", zamanSayaci);
                }
                score.text = (int)zamanSayaci + " Saniye icinde bitirdiniz.";
                highscore.text = "high score= " + (int)PlayerPrefs.GetFloat("zamanLVL1") + " saniye";
                //Lvl1hs.text = "HS: "+(int)PlayerPrefs.GetFloat("zamanLVL1") + " sn";

            }

            if (SceneManager.GetActiveScene().name == "Level_2")
            {
                if (PlayerPrefs.GetFloat("zamanLVL2") == 0)
                {
                    PlayerPrefs.SetFloat("zamanLVL2", zamanSayaci);
                }
                else if (PlayerPrefs.GetFloat("zamanLVL2") > zamanSayaci)
                {
                    PlayerPrefs.SetFloat("zamanLVL2", zamanSayaci);
                }
                score.text = (int)zamanSayaci + " Saniye icinde bitirdiniz.";
                highscore.text = "high score= " + (int)PlayerPrefs.GetFloat("zamanLVL2") + " saniye";
                //Lvl2hs.text = "HS: " + (int)PlayerPrefs.GetFloat("zamanLVL2") + " sn";
            }

            if (SceneManager.GetActiveScene().name == "Level_3")
            {
                if (PlayerPrefs.GetFloat("zamanLVL3") == 0)
                {
                    PlayerPrefs.SetFloat("zamanLVL3", zamanSayaci);
                }
                else if (PlayerPrefs.GetFloat("zamanLVL3") > zamanSayaci)
                {
                    PlayerPrefs.SetFloat("zamanLVL3", zamanSayaci);
                }
                score.text = (int)zamanSayaci + " Saniye icinde bitirdiniz.";
                highscore.text = "high score= " + (int)PlayerPrefs.GetFloat("zamanLVL3") + " saniye";
                //Lvl3hs.text = "HS: " + (int)PlayerPrefs.GetFloat("zamanLVL3") + " sn";
            }


            //score.text = (int)zamanSayaci + " Saniye içinde bitirdiniz.";
            //highscore.text = "high score= "+(int)PlayerPrefs.GetFloat("zaman") + " saniye";
            
            durum.text = "Bolum tamamlandi! Tebrikler.";
            //durum.gameObject.SetActive(true);
            
            replay.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
            nextlvl.gameObject.SetActive(true);
            score.gameObject.SetActive(true);
            highscore.gameObject.SetActive(true);
            can.gameObject.SetActive(false);
            zaman.gameObject.SetActive(false);
            coin.gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if(chest.GetComponent<Animator>().GetBool("openChest") == true)
        {
            Bonus.SetActive(true);
        }
    }
    void OnEnable()
    {
        Collectables.OnCollected += OnCollectableCollected;
        Collect.OnCollected += OnCollectableCollected;
    }
    void OnDisable()
    {
        Collectables.OnCollected -= OnCollectableCollected;
        Collect.OnCollected -= OnCollectableCollected;
    }

    void OnCollectableCollected()
    {
        count++;
        
        UpdateCount();
        
        
    }
    public void UpdateCount()
    {
        //coin.text = $"{count}/20";
        coin.text = $"{count}/{Collectables.total}";
    }
    void OnCollisionEnter(Collision other)
    {
        string objeIsmi = other.gameObject.name;

        if (objeIsmi.Equals("Diken"))
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
            if (canSayaci == 0)
            {
                oyunDevam = false;
            }
        }
        if (objeIsmi.Equals("Su"))
        {
            canSayaci = 0;
            can.text = canSayaci + "";
            AudioSource.PlayClipAtPoint(waterSplash, transform.position);
            if (canSayaci == 0)
            {
                oyunDevam = false;
            }
        }
    }
}
