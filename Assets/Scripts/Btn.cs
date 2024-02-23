using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    public GameObject credit;
    public GameObject Volume;
    public GameObject lvlPage;

    public GameObject lvl2btn, lvl3btn, lvl2img, lvl3img;
    public Text Lvl1hs, Lvl2hs, Lvl3hs;
    public AudioClip btnClick,btnClose;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Lvl1hs.text = "HS: " + (int)PlayerPrefs.GetFloat("zamanLVL1") + " sn";
        Lvl2hs.text = "HS: " + (int)PlayerPrefs.GetFloat("zamanLVL2") + " sn";
        Lvl3hs.text = "HS: " + (int)PlayerPrefs.GetFloat("zamanLVL3") + " sn";
    }
    /*void btnclick()
    {
        AudioSource.PlayClipAtPoint(btnClick, transform.position);
    }
    void btnclose()
    {
        AudioSource.PlayClipAtPoint(btnClose, transform.position);
    }*/

    public void openMenu()
    {
        SceneManager.LoadScene(0);
        
    }
    public void YenidenOynalvl1()
    {
        SceneManager.LoadScene(1);
        
    }
    public void YenidenOynalvl2()
    {
        SceneManager.LoadScene(2);
        
    }
    public void YenidenOynalvl3()
    {
        SceneManager.LoadScene(3);
        
    }
    public void lvlSelect()
    {
        
        lvlPage.SetActive(true);
        if (PlayerPrefs.GetFloat("zamanLVL1") != 0)
        {
            lvl2img.SetActive(false);
            lvl2btn.SetActive(true);
        }
        if (PlayerPrefs.GetFloat("zamanLVL2") != 0)
        {
            lvl3img.SetActive(false);
            lvl3btn.SetActive(true);
        }
    }
    public void lvlSelectexit()
    {
        lvlPage.SetActive(false);

    }
    public void Credits()
    {
        credit.SetActive(true);
        
    }
    public void closeCredit()
    {
        credit.SetActive(false);
    }
    public void openSettings()
    {
        Volume.SetActive(true);
        
    }
    public void closeSettings()
    {
        Volume.SetActive(false);
    }
    public void replay()
    {
        PlayerPrefs.DeleteAll();
        lvl2img.SetActive(true);
        lvl2btn.SetActive(false);
        lvl3img.SetActive(true);
        lvl3btn.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
