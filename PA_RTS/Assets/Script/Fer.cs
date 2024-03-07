using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fer : MonoBehaviour
{
    public GameObject player;
    

    private void OnTriggerEnter(Collider collision)
    {
        player.GetComponent<Player>().RecupererFer(collision.gameObject);
        
    }

    private void OnTriggerStay(Collider other)
    {
        player.GetComponent<Player>().RecupererFer(other.gameObject);
    }
}
