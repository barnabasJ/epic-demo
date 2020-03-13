using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private AudioSource audioSource;

    public void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CountUpdater.instance.pickupEvent.Invoke();
            gameObject.SetActive(false);
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
