using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CountUpdater.instance.pickupEvent.Invoke();
            gameObject.SetActive(false);
        }
    }
}
