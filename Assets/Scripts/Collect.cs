using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collect : MonoBehaviour
{
    public AudioClip CoinSound;
    public static event Action OnCollected;

    private void Awake()
    {

    }
    void Start()
    {

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
