using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fer : MonoBehaviour
{
    public GameObject player;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("human"))
        {
            player.GetComponent<Player>().recuperFer();
        }
    }

    
}
