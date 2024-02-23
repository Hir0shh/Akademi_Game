using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectables : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;
    public AudioClip CoinSound;
    private void Awake()
    {
        total = 0;
    }
    void Start()
    {
        total++;
        
    }


    void Update()
    {
        transform.Rotate(new Vector3(0, 40f, 0) * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            AudioSource.PlayClipAtPoint(CoinSound, transform.position);
            Destroy(gameObject);
        }
    }
}
