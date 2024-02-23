using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesEt : MonoBehaviour
{
    RaycastHit hit;
    public GameObject Silah;
    public GameObject Kapi;
    public GameObject chest;
    public AudioClip kapiSes;
    public AudioClip chestSes;
    private void Start()
    {
        //Silah.transform.position= (new Vector3(0, 1, 0));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Silah.transform.position,transform.forward,out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "gate")
                {
                    Kapi.GetComponent<Animator>().SetBool("DoorOpen", true);
                    AudioSource.PlayClipAtPoint(kapiSes, transform.position);
                    print("kapı açıldı.");
                }
                if (hit.collider.gameObject.tag == "chest")
                {
                    chest.GetComponent<Animator>().SetBool("openChest", true);
                    AudioSource.PlayClipAtPoint(chestSes, transform.position);
                    print("chest açıldı.");
                }
            }
        }
    }
}
