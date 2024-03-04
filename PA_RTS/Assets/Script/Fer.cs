using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fer : MonoBehaviour
{
    public GameObject player;
    

    private void OnTriggerEnter(Collider collision)
    {
        Console.Write("Collision");
        Debug.Log("Collision");
        player.GetComponent<Player>().RecupererFer(collision.gameObject);
        
    }

    private void OnTriggerStay(Collider other)
    {
        player.GetComponent<Player>().RecupererFer(other.gameObject);
    }
}
